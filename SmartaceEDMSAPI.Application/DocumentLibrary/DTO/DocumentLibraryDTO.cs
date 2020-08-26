using SmartaceEDMS.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application.DocumentLibrary.DTO
{
   public class DocumentLibraryDTO:BaseClass
    {
        public long DocumentLibraryTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ParentDocumentLibraryId { get; set; }
        public long DocumentLibraryPolicyId { get; set; }


    }

    public class DocumentLibraryDeleteDTO
    {
       
        public int CompanyId { get; set; }
        public long Id { get; set; }
        public long? ModifiedById { get; set; }
    }

    public   class DocumentLibraryFetchDTO {

        public long Id { get; set; } = DefaultValueMaps.DefaultId;
        public string name { get; set; } = "";
        public int pageNumber { get; set; } = DefaultValueMaps.pageNumber;
        public int pageSize { get; set; } = DefaultValueMaps.pageSize;
        public long parentDocumentId { get; set; } = DefaultValueMaps.DefaultId;
        public string Code { get; set; }



    }
}
