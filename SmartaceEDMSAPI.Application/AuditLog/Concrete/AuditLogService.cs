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
using SmartaceEDMS.API.Application.AuditLog.DTO;
using SmartaceEDMS.API.Application.AuditLog.Interface;
using Newtonsoft.Json;

namespace SmartaceEDMS.API.Application.AuditLog.Concrete
{
    public class AuditLogService : IAuditLogService
    {

        private readonly IRepository<Data.Models.AuditLog, long> _auditRepository;
        private readonly ICommonServices _commonServices;

        public AuditLogService(ICommonServices commonServices)
        {
            _commonServices = commonServices;

        }
        public async Task<bool> CreateAudit(AuditLogDTO payload)
        {

            try
            {
                // prepare the insert action
                var audit = new Data.Models.AuditLog()
                {
                    Id = 0,
                    Timestamp = DateTime.Now,
                    Domain = payload.Domain,
                    ItemId = payload.ItemId,
                    JsonVal = JsonConvert.SerializeObject(payload.JsonVal),
                    TextVal = payload.TextVal,
                    IsJson = payload.IsJson,
                    CompanyId = payload.CompanyId,
                    CreatedById = payload.CreatedById,

                };
                // perform any final action
                var response = await _auditRepository.InsertOrUpdateAsync(audit);

                return true;
            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);

                return false;
            }
        }

        public async Task<List<Data.Models.AuditLog>> FetchAudit(DateTime StartDate, DateTime EndDate,long Id = 0, 
                                                                    int pageNumber = 1, int pageSize = 100, bool DataFormatJson =true)
        {
            try
            {
                /// Fetch all record 
                var qry = _auditRepository.GetAll().AsQueryable();

                //Build your query

                if (Id > 0)
                {
                    qry = qry.Where(p => p.Id == Id).AsQueryable();
                }

                if (DataFormatJson == true)
                {
                    qry = qry.Where(p => p.IsJson == true).AsQueryable();
                }

                if (DataFormatJson == false)
                {
                    qry = qry.Where(p => p.IsJson == false).AsQueryable();
                }

                qry = qry.Where(p => p.DateCreated.Date >= StartDate.Date && p.DateCreated.Date <= EndDate);

                var data = qry.OrderBy(p => p.Id).Take(pageSize).Skip((pageNumber - DefaultValueMaps.StartCount) * pageSize).ToList();

                return data;
            }
            catch (Exception ex)
            {
                _commonServices.LogError(ex);
                return null;
            }
        }

    }
}