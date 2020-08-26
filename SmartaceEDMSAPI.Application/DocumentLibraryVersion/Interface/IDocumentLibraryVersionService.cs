using SmartaceEDMS.API.Application.DocumentLibraryVersion.DTO;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartaceEDMS.API.Application.DocumentLibraryVersion.Interface
{
   public interface IDocumentLibraryVersionService
    {

        #region Interface for Document Library Version Service CRUD
        Task<MessageOut> CreateDocumentLibraryVersion(DocumentLibraryVersionDTO payload);
        Task<MessageOut> UpdateDocumentLibraryVersion(DocumentLibraryVersionDTO payload);

        Task<MessageOut> DeleteDocumentLibraryVersion(DocumentLibraryVersionDeleteDTO payload);

        Task<List<Data.Models.DocumentLibraryVersion>> FetchDocumentLibraryVersion(DocumentLibraryVersionFetchDTO payload);

        #endregion

    }
}

