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
using SmartaceEDMS.API.Application.SharedServices.DTO;
using SmartaceEDMS.API.Data.Models;

namespace SmartaceEDMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentLibraryVersionController : BaseController
    {
        private readonly ILogger<DocumentLibraryVersionController> _logger;
        private readonly IDocumentLibraryVersionService _documentLibraryVersionsService;
        public DocumentLibraryVersionController(IDocumentLibraryVersionService documentLibraryVersionsService, ILogger<DocumentLibraryVersionController> logger)
        {
            _documentLibraryVersionsService = documentLibraryVersionsService;
            _logger = logger;
        }

        
        [HttpGet]
        [Route("DocumentLibraryVersion")]
        [ProducesResponseType(typeof(ApiResult<IList<DocumentLibraryVersion>>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FetchDocumentLibraryVersion([FromQuery] DocumentLibraryVersionFetchDTO payload)
        {
            
            var result = new ApiResult<IList<DocumentLibraryVersion>>
            {
                HasError = false,
                Result = await _documentLibraryVersionsService.FetchDocumentLibraryVersion(payload)
            };
            return Ok("Yes");
        }

        

        [HttpPost]
        [Route("DocumentLibraryVersion")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateDocumentLibraryVersion([FromBody] DocumentLibraryVersionDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLibraryVersionsService.CreateDocumentLibraryVersion(payload)
            };
            return Ok(result);
        }


        [HttpPost]
        [Route("DocumentLibraryVersion")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateDocumentLibraryVersion([FromBody] DocumentLibraryVersionDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLibraryVersionsService.UpdateDocumentLibraryVersion(payload)
            };
            return Ok(result);
        }




        [HttpPost]
        [Route("DocumentLibraryVersion")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteDocumentLibraryVersion([FromBody] DocumentLibraryVersionDeleteDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLibraryVersionsService.DeleteDocumentLibraryVersion(payload)
            };
            return Ok(result);
        }
    }
}
