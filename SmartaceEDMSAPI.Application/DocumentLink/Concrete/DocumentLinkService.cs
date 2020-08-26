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

namespace SmartaceEDMS.API.Application.DocumentLink.Concrete
{
    public class DocumentLinkService : IDocumentLinkService
    {
        private readonly ICommonServices _commonServices;
        private readonly IAuditLogService _auditLogService;
        private readonly EDMSAppContext _context;

        public DocumentLinkService(ICommonServices commonServices, IAuditLogService auditLogService, EDMSAppContext context)
        {
            _commonServices = commonServices;
            _auditLogService = auditLogService;
            _context = context;
        }

        public async Task<MessageOut> CreateDocumentLink(DocumentLinkDTO payload)
        {
            try
            {
                // Check it any record exist 

                var exists = await _context.DocumentLinks.FirstOrDefaultAsync(p => p.AccessCode == payload.AccessCode);

                if (exists == null)
                {

                    // prepare the insert action
                    exists = new Data.Models.DocumentLink()
                    {
                        DocumentFileId = payload.DocumentFileId,
                        GeneratedForId = payload.GeneratedForId,
                        IsGeneratedForExternalUser = payload.IsGeneratedForExternalUser,
                        MainURL = payload.MainURL,
                        ShortURL = payload.ShortURL,
                        StartDate = payload.StartDate,
                        ExternalUserEmail = payload.ExternalUserEmail,
                        ExternalUserPhone = payload.ExternalUserPhone,
                        UseCount = payload.UseCount,
                        MaxUseCount = payload.MaxUseCount,
                        EndDate = payload.EndDate,
                        AccessCode = payload.AccessCode,
                        GeneratedById = payload.GeneratedById,
                        IsActive = true,
                    };

                    _context.DocumentLinks.Add(exists);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordCreate.Replace("{0}", CommonModelNames.DOCUMENT_LINK));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordFail.Replace("{0}", CommonModelNames.DOCUMENT_LINK));
                    }
                }
                else
                {
                    /// record exist 
                    return _commonServices.OutputMessage(true, CommonResponseMessage.RecordExisting.Replace("{0}", CommonModelNames.DOCUMENT_LINK));

                }
            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Save, CommonModelNames.DOCUMENT_LINK, ex.Message));
            }
        }

        public async Task<MessageOut> DeleteDocumentLink(DocumentLinkDTO payload)
        {
            try
            {
                // Check it any record exist 

                var exists = await _context.DocumentLinks.FirstOrDefaultAsync(p => p.Id == payload.Id && p.CompanyId == payload.CompanyId);
                if (exists != null)
                {
                    var deleteRecord = await _context.DocumentLinks.FirstOrDefaultAsync(p => p.Id == payload.Id);

                    // prepare the delete action
                    deleteRecord.ModifiedById = payload.ModifiedById;
                    deleteRecord.IsActive = false;
                    deleteRecord.IsDeleted = true;

                    // delete the record
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordDelete.Replace("{0}", CommonModelNames.DOCUMENT_LINK));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordFailDelete.Replace("{0}", CommonModelNames.DOCUMENT_LINK));
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
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Delete, CommonModelNames.DOCUMENT_LINK, ex.Message));
            }
        }

        public async Task<List<Data.Models.DocumentLink>> FetchDocumentLink(DocumentLinkDTO payload)
        {
            try
            {
                /// Fetch all record 
                var qry = _context.DocumentLinks.AsQueryable();

                //Build your query

                if (payload.Id > 0)
                {
                    qry = qry.Where(p => p.Id == payload.Id).AsQueryable();
                }

                if (payload.DocumentFileId > 0)
                {
                    qry = qry.Where(p => p.DocumentFileId == payload.DocumentFileId).AsQueryable();
                }

                var data = qry.OrderBy(p => p.AccessCode).Take(payload.MaxUseCount).Skip((payload.UseCount - 1) * payload.MaxUseCount).ToList();

                return data;
            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return null;
            }
        }


        public async Task<MessageOut> UpdateDocumentLink(DocumentLinkDTO payload)
        {
            try
            {
                // Check it any record exist 

                var exists = _context.DocumentLinks.Where(x => x.Id != payload.Id && (x.AccessCode == payload.AccessCode)).Count();

                if (exists != 0)
                {
                    var UpdateRecord = await _context.DocumentLinks.FirstOrDefaultAsync(p => p.Id == payload.Id);

                    // prepare the update action


                    UpdateRecord.DocumentFileId = payload.DocumentFileId;
                    UpdateRecord.GeneratedForId = payload.GeneratedForId;
                    UpdateRecord.IsGeneratedForExternalUser = payload.IsGeneratedForExternalUser;
                    UpdateRecord.MainURL = payload.MainURL;
                    UpdateRecord.ShortURL = payload.ShortURL;
                    UpdateRecord.StartDate = payload.StartDate;
                    UpdateRecord.ExternalUserEmail = payload.ExternalUserEmail;
                    UpdateRecord.ExternalUserPhone = payload.ExternalUserPhone;
                    UpdateRecord.UseCount = payload.UseCount;
                    UpdateRecord.MaxUseCount = payload.MaxUseCount;
                    UpdateRecord.EndDate = payload.EndDate;
                    UpdateRecord.AccessCode = payload.AccessCode;
                    UpdateRecord.GeneratedById = payload.GeneratedById;
                    UpdateRecord.IsActive = true;

                    // update the record
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordUpdate.Replace("{0}", CommonModelNames.DOCUMENT_LINK));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordUpdateFail.Replace("{0}", CommonModelNames.DOCUMENT_LINK));
                    }


                }
                else
                {
                    return _commonServices.OutputMessage(false, CommonResponseMessage.RecordNotFound.Replace("{0}", CommonModelNames.DOCUMENT_LINK));
                }

            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Update, CommonModelNames.DOCUMENT_LINK, ex.Message));
            }
        }
    }
}
