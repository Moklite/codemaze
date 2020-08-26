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
using SmartaceEDMS.API.Application.SharedServices.DTO;
using SmartaceEDMS.API.Data.Models;

namespace SmartaceEDMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentLibraryController : BaseController
    {
        private readonly ILogger<DocumentLibraryController> _logger;
        private readonly IDocumentLibraryService _documentLibraryService;
        public DocumentLibraryController(IDocumentLibraryService documentLibraryService, ILogger<DocumentLibraryController> logger)
        {
            _documentLibraryService = documentLibraryService;
            _logger = logger;
        }

        
        [HttpGet]
        [Route("DocumentLibrary")]
        [ProducesResponseType(typeof(ApiResult<IList<DocumentLibrary>>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FetchDocumentLibrary([FromQuery] DocumentLibraryFetchDTO payload)
        {
            
            var result = new ApiResult<IList<DocumentLibrary>>
            {
                HasError = false,
                Result = await _documentLibraryService.FetchDocumentLibrary(payload)
            };
            return Ok("Yes");
        }

        

        [HttpPost]
        [Route("DocumentLibrary")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateDocumentLibrary([FromBody] DocumentLibraryDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLibraryService.CreateDocumentLibrary(payload)
            };
            return Ok(result);
        }


        [HttpPost]
        [Route("DocumentLibrary")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateDocumentLibrary([FromBody] DocumentLibraryDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLibraryService.UpdateDocumentLibrary(payload)
            };
            return Ok(result);
        }




        [HttpPost]
        [Route("DocumentLibrary")]
        [ProducesResponseType(typeof(ApiResult<MessageOut>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteDocumentLibrary([FromBody] DocumentLibraryDeleteDTO payload)
        {
            var result = new ApiResult<MessageOut>
            {
                HasError = false,
                Result = await _documentLibraryService.DeleteDocumentLibrary(payload)
            };
            return Ok(result);
        }
    }
}
