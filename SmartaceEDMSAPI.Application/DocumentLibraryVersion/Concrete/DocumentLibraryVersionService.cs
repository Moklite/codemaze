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
using SmartaceEDMS.API.Application.DocumentLibraryVersion.DTO;
using SmartaceEDMS.API.Application.DocumentLibraryVersion.Interface;
using Microsoft.EntityFrameworkCore;

namespace SmartaceEDMS.API.Application.DocumentLibraryVersion.Concrete
{
    public class DocumentLibraryVersionService : IDocumentLibraryVersionService
    {
        private readonly ICommonServices _commonServices;
        private readonly IAuditLogService _auditLogService;
        private readonly EDMSAppContext _context;

        public DocumentLibraryVersionService(ICommonServices commonServices, IAuditLogService auditLogService, EDMSAppContext context)
        {
            _commonServices = commonServices;
            _auditLogService = auditLogService;
            _context = context;
        }

        public async Task<MessageOut> CreateDocumentLibraryVersion(DocumentLibraryVersionDTO payload)
        {

            try
            {
                // Check it any record exist 

                var exists = await _context.DocumentLibraryVersions.FirstOrDefaultAsync(p => p.VersionNo == payload.VersionNo);

                if (exists == null)
                {

                    // prepare the insert action
                    exists = new Data.Models.DocumentLibraryVersion()
                    {
                        FileExt = payload.FileExt,
                        FileSize = payload.FileSize,
                        StorageTypeId = payload.StorageTypeId,
                        StorageURLPath = payload.StorageURLPath,
                        VersionNo = payload.VersionNo,
                        CompanyId = payload.CompanyId,
                        CreatedById = payload.CreatedById,
                        DocumentFileId = payload.DocumentFileId,
                        IsActive = true,
                    };

                    _context.DocumentLibraryVersions.Add(exists);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordCreate.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY_VERSION));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordFail.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY_VERSION));
                    }
                }
                else
                {
                    /// record exist 
                    return _commonServices.OutputMessage(true, CommonResponseMessage.RecordExisting.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY_VERSION));

                }
            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Save, CommonModelNames.DOCUMENT_LIBRARY_VERSION, ex.Message));
            }

        }


        public async Task<MessageOut> UpdateDocumentLibraryVersion(DocumentLibraryVersionDTO payload)
        {

            try
            {
                // Check it any record exist 

                var exists = _context.DocumentLibraryVersions.Where(x => x.Id != payload.Id && (x.VersionNo == payload.VersionNo)).Count();

                if (exists != 0)
                {
                    var UpdateRecord = await _context.DocumentLibraryVersions.FirstOrDefaultAsync(p => p.Id == payload.Id);

                    // prepare the update action

                    UpdateRecord.FileExt = payload.FileExt;
                    UpdateRecord.FileSize = payload.FileSize;
                    UpdateRecord.StorageTypeId = payload.StorageTypeId;
                    UpdateRecord.StorageURLPath = payload.StorageURLPath;
                    UpdateRecord.VersionNo = payload.VersionNo;
                    UpdateRecord.CompanyId = payload.CompanyId;
                    UpdateRecord.ModifiedById = payload.ModifiedById;
                    UpdateRecord.IsActive = payload.IsActive;

                    // update the record
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordUpdate.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY_VERSION));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordUpdateFail.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY_VERSION));
                    }


                }
                else
                {
                    return _commonServices.OutputMessage(false, CommonResponseMessage.RecordNotFound.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY_VERSION));
                }

            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Update, CommonModelNames.DOCUMENT_LIBRARY_VERSION, ex.Message));
            }

        }


        public async Task<MessageOut> DeleteDocumentLibraryVersion(DocumentLibraryVersionDeleteDTO payload)
        {

            try
            {
                // Check it any record exist 

                var exists = await _context.DocumentLibraryVersions.FirstOrDefaultAsync(p => p.Id == payload.Id && p.CompanyId == payload.CompanyId);
                if (exists != null)
                {
                    var deleteRecord = await _context.DocumentLibraryVersions.FirstOrDefaultAsync(p => p.Id == payload.Id);

                    // prepare the delete action
                    deleteRecord.ModifiedById = payload.ModifiedById;
                    deleteRecord.IsActive = false;
                    deleteRecord.IsDeleted = true;

                    // delete the record
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordDelete.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY_VERSION));
                    }
                    else
                    {
                        return _commonServices.OutputMessage(true, CommonResponseMessage.RecordFailDelete.Replace("{0}", CommonModelNames.DOCUMENT_LIBRARY_VERSION));
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
                return _commonServices.OutputMessage(false, String.Format(CommonResponseMessage.InternalError, OperationType.Delete, CommonModelNames.DOCUMENT_LIBRARY_VERSION, ex.Message));
            }

        }

       

        public async Task<List<Data.Models.DocumentLibraryVersion>> FetchDocumentLibraryVersion(DocumentLibraryVersionFetchDTO payload)
        {
            try
            {
                /// Fetch all record 
                var qry = _context.DocumentLibraryVersions.AsQueryable();

                //Build your query

                if (payload.Id > 0)
                {
                    qry = qry.Where(p => p.Id == payload.Id).AsQueryable();
                }

                if (payload.VersionNo > 0)
                {
                    qry = qry.Where(p => p.VersionNo== payload.VersionNo).AsQueryable();
                }
               
                var data = qry.OrderBy(p => p.VersionNo).Take(payload.pageSize).Skip((payload.pageNumber - 1) * payload.pageSize).ToList();

                return data;
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
