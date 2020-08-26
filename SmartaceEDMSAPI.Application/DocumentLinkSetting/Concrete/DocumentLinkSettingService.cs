using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using SmartaceEDMS.API.Application.DocumentLibrary.DTO;
using SmartaceEDMS.API.Application.DocumentLibrary.Interface;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using SmartaceEDMS.API.Application.SharedServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartaceEDMS.API;
using System.Linq;
using SmartaceEDMS.API.Application.AuditLog.Interface;
using SmartaceEDMS.API.Application.AuditLog.DTO;
using SmartaceEDMS.API.Data;
using Microsoft.EntityFrameworkCore.Update.Internal;
using SmartaceEDMS.API.Application.DocumentLinkSetting.DTO;
using SmartaceEDMS.API.Application.DocumentLinkSetting.Interface;
using SmartaceEDMS.API.Application.DocumentLinkLog.Interface;
using SmartaceEDMS.API.Application.DocumentLinkLog.DTO;
using Microsoft.EntityFrameworkCore;

namespace SmartaceEDMS.API.Application.DocumentLinkSetting.Concrete
{
    public class DocumentLinkSettingService : IDocumentLinkSettingService
    {
        private readonly ICommonServices _commonServices;
        private readonly IAuditLogService _auditLogService;
        private readonly EDMSAppContext _context;

        public DocumentLinkSettingService(ICommonServices commonServices, IAuditLogService auditLogService, EDMSAppContext context)
        {
            _commonServices = commonServices;
            _auditLogService = auditLogService;
            _context = context;
        }

        public async Task<MessageOut> CreateDocumentLinkSetting(DocumentLinkSettingDTO payload)
        {
            try
            {
                // Check it any record exist 

                var exists = await _context.DocumentLinkSettings.FirstOrDefaultAsync(p => p.DocumentLinkId == payload.DocumentLinkId);


                if (exists == null)
                {

                    // prepare the insert action
                    exists = new Data.Models.DocumentLinkSetting()
                    {
                        DocumentLinkId = payload.DocumentLinkId,
                        AccessModeId = payload.AccessModeId, 
                    };

                    _context.DocumentLinkSettings.Add(exists);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordCreate.Replace("{0}", CommonModelNames.DOCUMENT_LINK_SETTING));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordFail.Replace("{0}", CommonModelNames.DOCUMENT_LINK_SETTING));
                    }
                }
                else
                {
                    /// record exist 
                    return _commonServices.OutputMessage(true, CommonResponseMessage.RecordExisting.Replace("{0}", CommonModelNames.DOCUMENT_LINK_SETTING));

                }
            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Save, CommonModelNames.DOCUMENT_LINK_SETTING, ex.Message));
            }
        }

        public Task<MessageOut> DeleteDocumentLinkSetting(DocumentLinkSettingDTO payload)
        {
            throw new NotImplementedException();
        }

        public Task<List<Data.Models.DocumentLink>> FetchDocumentLinkSetting(DocumentLinkSettingDTO payload)
        {
            throw new NotImplementedException();
        }

        public Task<MessageOut> UpdateDocumentLinkSetting(DocumentLinkSettingDTO payload)
        {
            throw new NotImplementedException();
        }
    }
}
