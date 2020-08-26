using Abp.Application.Services;
using SmartaceEDMS.API.Application.GlobalOptions.DTO;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using SmartaceEDMS.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartaceEDMS.API.Application.GlobalOptions.Interface
{
    public interface IGlobalOptionService : IApplicationService
    {
        //Task<IList<GlobalOption>> GetGlobalOptions(string name);

        //Task<MessageOut> SaveGlobalOption(GlobalOptionDTO payload);
    }
}
