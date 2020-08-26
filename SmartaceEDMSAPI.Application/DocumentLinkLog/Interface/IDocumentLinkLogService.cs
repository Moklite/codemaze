using SmartaceEDMS.API.Application.DocumentLink.DTO;
using SmartaceEDMS.API.Application.DocumentLinkLog.DTO;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartaceEDMS.API.Application.DocumentLinkLog.Interface
{
    public interface IDocumentLinkLogService
    {
        #region Interface for Document Link Service CRUD
        Task<MessageOut> CreateDocumentLinkLog(DocumentLinkLogDTO payload);
        Task<MessageOut> UpdateDocumentLinkLog(DocumentLinkLogDTO payload);

        Task<MessageOut> DeleteDocumentLinkLog(DocumentLinkLogDTO payload);

        Task<List<Data.Models.DocumentLink>> FetchDocumentLinkLog(DocumentLinkLogDTO payload);

        #endregion
    }
}
