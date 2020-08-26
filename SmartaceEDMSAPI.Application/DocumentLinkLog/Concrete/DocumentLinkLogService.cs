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
using SmartaceEDMS.API.Application.DocumentLink.DTO;
using SmartaceEDMS.API.Application.DocumentLink.Interface;
using Microsoft.EntityFrameworkCore;
using SmartaceEDMS.API.Application.DocumentLinkLog.Interface;
using SmartaceEDMS.API.Application.DocumentLinkLog.DTO;
using System.Linq.Dynamic.Core;

namespace SmartaceEDMS.API.Application.DocumentLinkLog.Concrete
{
    public class DocumentLinkLogService : IDocumentLinkLogService
    {
        private readonly ICommonServices _commonServices;
        private readonly IAuditLogService _auditLogService;
        private readonly EDMSAppContext _context;

        public DocumentLinkLogService(ICommonServices commonServices, IAuditLogService auditLogService, EDMSAppContext context)
        {
            _commonServices = commonServices;
            _auditLogService = auditLogService;
            _context = context;
        }

        public async Task<MessageOut> CreateDocumentLinkLog(DocumentLinkLogDTO payload)
        {
            try
            {
                // Check it any record exist 

                var exists = await _context.DocumentLinkLogs.FirstOrDefaultAsync(p => p.DocumentLinkId == payload.DocumentLinkId);

                if (exists == null)
                {

                    // prepare the insert action
                    exists = new Data.Models.DocumentLinkLog()
                    {
                        DocumentLinkId = payload.DocumentLinkId,
                        DateViewed = payload.DateViewed,
                        OtherInfo = payload.OtherInfo,
                        IPAddress = payload.IPAddress,
                        IsActive = true,
                    };

                    _context.DocumentLinkLogs.Add(exists);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordCreate.Replace("{0}", CommonModelNames.DOCUMENT_LINK_LOG));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordFail.Replace("{0}", CommonModelNames.DOCUMENT_LINK_LOG));
                    }
                }
                else
                {
                    /// record exist 
                    return _commonServices.OutputMessage(true, CommonResponseMessage.RecordExisting.Replace("{0}", CommonModelNames.DOCUMENT_LINK_LOG));

                }
            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Save, CommonModelNames.DOCUMENT_LINK_LOG, ex.Message));
            }
        }

        public async Task<MessageOut> DeleteDocumentLinkLog(DocumentLinkLogDTO payload)
        {
            try
            {
                // Check it any record exist 

                var exists = await _context.DocumentLinkLogs.FirstOrDefaultAsync(p => p.Id == payload.Id && p.CompanyId == payload.CompanyId);
                if (exists != null)
                {
                    var deleteRecord = await _context.DocumentLinkLogs.FirstOrDefaultAsync(p => p.Id == payload.Id);

                    // prepare the delete action
                    deleteRecord.ModifiedById = payload.ModifiedById;
                    deleteRecord.IsActive = false;
                    deleteRecord.IsDeleted = true;

                    // delete the record
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordDelete.Replace("{0}", CommonModelNames.DOCUMENT_LINK_LOG));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordFailDelete.Replace("{0}", CommonModelNames.DOCUMENT_LINK_LOG));
                    }

                }
                else
                {
                    return _commonServices.OutputMessage(false, CommonResponseMessage.RecordNotFound);
                }

            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Delete, CommonModelNames.DOCUMENT_LINK_LOG, ex.Message));
            }
        }

        public async Task<List<Data.Models.DocumentLink>> FetchDocumentLinkLog(DocumentLinkLogDTO payload)
        {
            try
            {
                /// Fetch all record 
                var qry = _context.DocumentLinkLogs.AsQueryable();

                //Build your query

                if (payload.Id > 0)
                {
                    qry = qry.Where(p => p.Id == payload.Id).AsQueryable();
                }

                if (payload.DocumentLinkId > 0)
                {
                    qry = qry.Where(p => p.DocumentLinkId == payload.DocumentLinkId).AsQueryable();
                }

                var data = qry.OrderBy(p => p.IPAddress).Take(payload.OtherInfo).Skip((payload. - 1) * payload.DateViewed).ToList();

                return data;
            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return null;
            }
        } 

        public async Task<MessageOut> UpdateDocumentLinkLog(DocumentLinkLogDTO payload)
        {
            try
            {
                // Check it any record exist 

                var exists = _context.DocumentLinkLogs.Where(x => x.Id != payload.Id && (x.DocumentLinkId == payload.DocumentLinkId)).Count();

                if (exists != 0)
                {
                    var UpdateRecord = await _context.DocumentLinkLogs.FirstOrDefaultAsync(p => p.Id == payload.Id);

                    // prepare the update action


                    UpdateRecord.DocumentLinkId = payload.DocumentLinkId;
                    UpdateRecord.DateViewed = payload.DateViewed;
                    UpdateRecord.OtherInfo = payload.OtherInfo;
                    UpdateRecord.IPAddress = payload.IPAddress;
                    UpdateRecord.IsActive = true;

                    // update the record
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordUpdate.Replace("{0}", CommonModelNames.DOCUMENT_LINK_LOG));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordUpdateFail.Replace("{0}", CommonModelNames.DOCUMENT_LINK_LOG));
                    }


                }
                else
                {
                    return _commonServices.OutputMessage(false, CommonResponseMessage.RecordNotFound.Replace("{0}", CommonModelNames.DOCUMENT_LINK_LOG));
                }

            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Update, CommonModelNames.DOCUMENT_LINK_LOG, ex.Message));
            }
        }
    }
}//fix the fetchdocument
