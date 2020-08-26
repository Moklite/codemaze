using SmartaceEDMS.API.Application.DocumentLinkSetting.DTO;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartaceEDMS.API.Application.DocumentLinkSetting.Interface
{
    public interface IDocumentLinkSettingService
    {
        #region Interface for Document Link Service CRUD
        Task<MessageOut> CreateDocumentLinkSetting(DocumentLinkSettingDTO payload);
        Task<MessageOut> UpdateDocumentLinkSetting(DocumentLinkSettingDTO payload);

        Task<MessageOut> DeleteDocumentLinkSetting(DocumentLinkSettingDTO payload);

        Task<List<Data.Models.DocumentLink>> FetchDocumentLinkSetting(DocumentLinkSettingDTO payload);

        #endregion
    }
}
