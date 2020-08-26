
using SmartaceEDMS.API.Application.DocumentLibrary.DTO;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartaceEDMS.API.Application.DocumentLibrary.Interface
{
     public interface IDocumentLibraryService 
    {
        #region Interface for Document Library Service CRUD
        Task<MessageOut> CreateDocumentLibrary(DocumentLibraryDTO payload);
        Task<MessageOut> UpdateDocumentLibrary(DocumentLibraryDTO payload);

        Task<MessageOut> DeleteDocumentLibrary(DocumentLibraryDeleteDTO payload);

        Task<List<Data.Models.DocumentLibrary>> FetchDocumentLibrary(DocumentLibraryFetchDTO payload);
  
        #endregion
    }
}
