using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartaceEDMS.API.Application;
using SmartaceEDMS.API.Application.DocumentLibrary.DTO;
using SmartaceEDMS.API.Application.DocumentLibrary.Interface;
using SmartaceEDMS.API.Application.DocumentLinkLog.DTO;
using SmartaceEDMS.API.Application.DocumentLinkLog.Interface;
using SmartaceEDMS.API.Application.DocumentLink.DTO;
using SmartaceEDMS.API.Application.DocumentLink.Interface;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using SmartaceEDMS.API.Data.Models;

namespace SmartaceEDMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentLinkLogController : BaseController
    {
        private readonly ILogger<DocumentLinkLogController> _logger;
        private readonly IDocumentLinkLogService _documentLinkLogsService;
        public DocumentLinkLogController(IDocumentLinkLogService documentLinkLogsService, ILogger<DocumentLinkLogController> logger)
        {
            _documentLinkLogsService = documentLinkLogsService;
            _logger = logger;
        }


        [HttpGet]
        [Route("DocumentLinkLog")]
        [ProducesResponseType(typeof(ApiResult<IList<DocumentLinkLog>>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FetchDocumentLinkLog([FromQuery] DocumentLinkLogDTO payload)
        {

            var result = new ApiResult<IList<DocumentLinkLog>>
            {
                HasError = false,
                Result = await _documentLinkLogsService.FetchDocumentLinkLog(payload)
            };
            return Ok("Yes");
        }



        [HttpPost]
        [Route("DocumentLinkLog")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateDocumentLinkLog([FromBody] DocumentLinkLogDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLinkLogsService.CreateDocumentLinkLog(payload)
            };
            return Ok(result);
        }


        [HttpPost]
        [Route("DocumentLinkLog")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateDocumentLinkLog([FromBody] DocumentLinkLogDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLinkLogsService.UpdateDocumentLinkLog(payload)
            };
            return Ok(result);
        }




        [HttpPost]
        [Route("DocumentLinkLog")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteDocumentLinkLog([FromBody] DocumentLinkLogDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLinkLogsService.DeleteDocumentLinkLog(payload)
            };
            return Ok(result);
        }
    }
}
