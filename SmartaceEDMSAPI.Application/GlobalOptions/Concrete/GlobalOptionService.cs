using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartaceEDMS.API.Application.GlobalOptions.DTO;
using SmartaceEDMS.API.Application.GlobalOptions.Interface;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using SmartaceEDMS.API.Application.SharedServices.Interface;
using SmartaceEDMS.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace SmartaceEDMS.API.Application.GlobalOptions.Concrete
{
    public class GlobalOptionService : IGlobalOptionService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager; 
        private readonly IRepository<GlobalOption, long> _globalOptionRepository;
        private readonly ICommonServices _commonServices;
        private readonly IMapper _mapper;
        public GlobalOptionService(
            //IUnitOfWorkManager unitOfWorkManager, 
           //IRepository<GlobalOption, long> globalOptionRepository,
            ICommonServices commonServices)
        {
            //_unitOfWorkManager = unitOfWorkManager;
           // _globalOptionRepository = globalOptionRepository;
            _commonServices = commonServices;
            //_mapper = mapper;
        }

        //public async Task<IList<GlobalOption>> GetGlobalOptions(string name = "")
        //{
        //    var qry = _globalOptionRepository.GetAll().AsQueryable();

        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        qry.Where(p => p.Name == name);
        //    }

        //    var model = await qry.ToListAsync();

        //    return model;
        //}

        //public async Task<MessageOut> SaveGlobalOption(GlobalOptionDTO payload)
        //{
        //    try
        //    {
        //        var exists = await _globalOptionRepository.FirstOrDefaultAsync(p => p.Name == payload.Name);

        //        if (exists == null)
        //        {
        //            exists = new GlobalOption()
        //            {
        //                Id = 0,
        //                Name = payload.Name,
        //                Value = payload.Value
        //            };
        //        }
        //        else
        //        {
        //            exists.Value = payload.Value;
        //        }

        //        var response = await _globalOptionRepository.InsertOrUpdateAsync(exists);

        //        return _commonServices.OutputMessage(true, "Global Option Saved Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        _commonServices.LogError(ex);

        //        return _commonServices.OutputMessage(false, "Failed to Save Global Option");
        //    }
        //}

    }
}
