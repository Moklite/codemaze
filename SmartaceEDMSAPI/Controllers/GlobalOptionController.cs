using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartaceEDMS.API.Application;
using SmartaceEDMS.API.Application.GlobalOptions.DTO;
using SmartaceEDMS.API.Application.GlobalOptions.Interface;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using SmartaceEDMS.API.Data.Models;

namespace SmartaceEDMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GlobalOptionController : BaseController
    {
        private readonly ILogger<GlobalOptionController> _logger;
        private readonly IGlobalOptionService _globalOptionService;
        public GlobalOptionController(
            IGlobalOptionService globalOptionService,
            ILogger<GlobalOptionController> logger)
        {
            _globalOptionService = globalOptionService;
            _logger = logger;
        }

        //[AbpAuthorize(PermissionNames.GetGlobalOption)]
        [HttpGet]
        [Route("GetOption")]
        [ProducesResponseType(typeof(ApiResult<IList<GlobalOption>>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetOption(string name= "")
        {
            //var result = new ApiResult<IList<GlobalOption>>
            //{
            //    HasError = false,
            //    Result = new List<GlobalOption>()//await _globalOptionService.GetGlobalOptions(name)
            //};
            return Ok("Yes");
        }

        //[AbpAuthorize(PermissionNames.SaveGlobalOption)]
        [HttpPost]
        [Route("SaveOption")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SaveOption([FromBody] GlobalOptionDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = new MessageOut() //  await _globalOptionService.SaveGlobalOption(payload)
            };
            return Ok(result);
        }
    }
}
