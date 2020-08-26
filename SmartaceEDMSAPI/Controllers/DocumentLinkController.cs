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
using SmartaceEDMS.API.Application.DocumentLibraryVersion.DTO;
using SmartaceEDMS.API.Application.DocumentLibraryVersion.Interface;
using SmartaceEDMS.API.Application.DocumentLink.DTO;
using SmartaceEDMS.API.Application.DocumentLink.Interface;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using SmartaceEDMS.API.Data.Models;

namespace SmartaceEDMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentLinkController : BaseController
    {
        private readonly ILogger<DocumentLinkController> _logger;
        private readonly IDocumentLinkService _documentLinksService;
        public DocumentLinkController(IDocumentLinkService documentLinksService, ILogger<DocumentLinkController> logger)
        {
            _documentLinksService = documentLinksService;
            _logger = logger;
        }


        [HttpGet]
        [Route("DocumentLink")]
        [ProducesResponseType(typeof(ApiResult<IList<DocumentLink>>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FetchDocumentLink([FromQuery] DocumentLinkDTO payload)
        {

            var result = new ApiResult<IList<DocumentLink>>
            {
                HasError = false,
                Result = await _documentLinksService.FetchDocumentLink(payload)
            };
            return Ok("Yes");
        }



        [HttpPost]
        [Route("DocumentLink")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateDocumentLink([FromBody] DocumentLinkDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLinksService.CreateDocumentLink(payload)
            };
            return Ok(result);
        }


        [HttpPost]
        [Route("DocumentLink")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateDocumentLink([FromBody] DocumentLinkDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLinksService.UpdateDocumentLink(payload)
            };
            return Ok(result);
        }




        [HttpPost]
        [Route("DocumentLink")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteDocumentLink([FromBody] DocumentLinkDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLinksService.DeleteDocumentLink(payload)
            };
            return Ok(result);
        }
    }
}
