using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartaceEDMSAPI.Application;

namespace SmartaceEDMS.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected BaseController()
        {
          //  LocalizationSourceName = AppConstants.LocalizationSourceName;
        }

        //protected void CheckErrors(IdentityResult identityResult)
        //{
        //    identityResult.CheckErrors(LocalizationManager);
        //}
    }
}
