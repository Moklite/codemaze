
using SmartaceEDMS.API.Application.AuditLog.DTO;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartaceEDMS.API.Application.AuditLog.Interface
{
     public interface IAuditLogService
    {
        #region Interface for Audit Log Create & Read
        Task<bool> CreateAudit(AuditLogDTO payload);

        Task<List<Data.Models.AuditLog>> FetchAudit(DateTime StartDate, DateTime EndDate, long Id = DefaultValueMaps.DefaultId,
                                                                    int pageNumber = 1, int pageSize = DefaultValueMaps.pageSize, bool DataFormatJson = true);
        #endregion
    }
}
