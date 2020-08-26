using SmartaceEDMS.API.Application.DocumentLink.DTO;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartaceEDMS.API.Application.DocumentLink.Interface
{
   
    public interface IDocumentLinkService
    {
        #region Interface for Document Link Service CRUD
        Task<MessageOut> CreateDocumentLink(DocumentLinkDTO payload);
        Task<MessageOut> UpdateDocumentLink(DocumentLinkDTO payload);

        Task<MessageOut> DeleteDocumentLink(DocumentLinkDTO payload);

        Task<List<Data.Models.DocumentLink>> FetchDocumentLink(DocumentLinkDTO payload);

        #endregion
    }
}
