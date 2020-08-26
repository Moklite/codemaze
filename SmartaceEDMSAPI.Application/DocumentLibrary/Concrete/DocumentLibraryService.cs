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
using Microsoft.EntityFrameworkCore;

namespace SmartaceEDMS.API.Application.DocumentLibrary.Concrete
{
    public class DocumentLibraryService : IDocumentLibraryService
    {
       
        
        private readonly ICommonServices _commonServices;
        private readonly IAuditLogService _auditLogService;
        private readonly EDMSAppContext _context;

        public DocumentLibraryService(ICommonServices commonServices, IAuditLogService auditLogService, EDMSAppContext context)
        {
            _commonServices = commonServices;
            _auditLogService = auditLogService;
            _context = context;
         
        }
        public async Task<MessageOut> CreateDocumentLibrary(DocumentLibraryDTO payload)
        {

            try
            {

                string checkValue = payload.Name;

                // Check it any record exist 

                var exists = await _context.DocumentLibraries.FirstOrDefaultAsync(p => p.Name.ToLower().Trim() == checkValue.ToLower().Trim());

                if (exists == null)
                {

                    // prepare the insert action
                    exists = new Data.Models.DocumentLibrary()
                    {
                        Name = payload.Name,
                        Code = payload.Code,
                        Description = payload.Description,
                        DocumentLibraryPolicyId = payload.DocumentLibraryPolicyId,
                        DocumentLibraryTypeId = payload.DocumentLibraryTypeId,
                        ParentDocumentLibraryId = payload.ParentDocumentLibraryId,
                        CompanyId = payload.CompanyId,
                        CreatedById = payload.CreatedById,

                    };

                    _context.DocumentLibraries.Add(exists);
                   
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordCreate.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordFail.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY));
                    }
                }
                else
                {
                    /// record exist 
                    exists.Name = payload.Name;
                    return _commonServices.OutputMessage(true, CommonResponseMessage.RecordExisting.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY));

                }
            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Save, CommonModelNames.DOCUMENT_LIBRARY, ex.Message));
            }

        }


        public async Task<MessageOut> UpdateDocumentLibrary(DocumentLibraryDTO payload)
        {

            try
            {
                // Check it any record exist 

                var exists = _context.DocumentLibraries.Where(x => x.Id != payload.Id && (x.Name.Trim() == payload.Name.Trim())).Count();

                if (exists != 0)
                {
                    var UpdateRecord = await _context.DocumentLibraries.FirstOrDefaultAsync(p => p.Id == payload.Id);

                    // prepare the update action
                    UpdateRecord.Name = payload.Name;
                    UpdateRecord.Code = payload.Code;
                    UpdateRecord.Description = payload.Description;
                    UpdateRecord.DocumentLibraryPolicyId = payload.DocumentLibraryPolicyId;
                    UpdateRecord.DocumentLibraryTypeId = payload.DocumentLibraryTypeId;
                    UpdateRecord.ParentDocumentLibraryId = payload.ParentDocumentLibraryId;
                    UpdateRecord.CompanyId = payload.CompanyId;
                    UpdateRecord.ModifiedById = payload.ModifiedById;
                    UpdateRecord.IsActive = payload.IsActive;

                    // update the record
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordUpdate.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordUpdateFail.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY));
                    }

                   
                }
                else
                {
                    return _commonServices.OutputMessage(false, CommonResponseMessage.RecordNotFound.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY));
                }

            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Update, CommonModelNames.DOCUMENT_LIBRARY, ex.Message));
            }

        }

 
         public async Task<MessageOut> DeleteDocumentLibrary(DocumentLibraryDeleteDTO payload)
        {

            try
            {
                // Check it any record exist 

                var exists = await _context.DocumentLibraries.FirstOrDefaultAsync(p => p.Id == payload.Id && p.CompanyId == payload.CompanyId);
                if (exists != null)
                {
                    var deleteRecord = await _context.DocumentLibraries.FirstOrDefaultAsync(p => p.Id == payload.Id);

                    // prepare the delete action
                    deleteRecord.ModifiedById = payload.ModifiedById;
                    deleteRecord.IsActive = false;
                    deleteRecord.IsDeleted = true;

                    // delete the record
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordDelete.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordFailDelete.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY));
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
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Delete, CommonModelNames.DOCUMENT_LIBRARY, ex.Message));
            }

        }



        public async Task<List<Data.Models.DocumentLibrary>> FetchDocumentLibrary(DocumentLibraryFetchDTO payload)
        {
            try
            {
                /// Fetch all record 
                var qry = _context.DocumentLibraries.AsQueryable();
              
                //Build your query
                
                if (payload.Id > 0)
                {
                    qry = qry.Where(p => p.Id == payload.Id).AsQueryable();    
                }

                if (payload.name != "")
                {
                    qry = qry.Where(p => p.Name == payload.name).AsQueryable();
                }
                if (payload.parentDocumentId > 0)
                {
                    qry = qry.Where(p => p.ParentDocumentLibraryId == payload.parentDocumentId).AsQueryable();
                }
                
                var data =  qry.OrderBy(p => p.Name).Take(payload.pageSize).Skip((payload.pageNumber - 1) * payload.pageSize).ToList();

                return  data;
            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return null;
            }
        }



        #region Audit Log 
        public void AuditLog(AuditLogDTO payload)
        {
            _auditLogService.CreateAudit(payload);
        }
        #endregion
    }
}
