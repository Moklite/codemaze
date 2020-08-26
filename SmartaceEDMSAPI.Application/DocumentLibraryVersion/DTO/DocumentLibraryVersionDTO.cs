using SmartaceEDMS.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application.DocumentLibraryVersion.DTO
{
    public class DocumentLibraryVersionDTO : BaseClass
    {
        public long DocumentFileId { get; set; }
        public string FileExt { get; set; }
        public decimal FileSize { get; set; }  //in kilobytes
        public long StorageTypeId { get; set; }
        public string StorageURLPath { get; set; }
        public int VersionNo { get; set; }
    }


    public class DocumentLibraryVersionDeleteDTO
    {

        public int CompanyId { get; set; }
        public long Id { get; set; }
        public long? ModifiedById { get; set; }
    }


    public class DocumentLibraryVersionFetchDTO
    {

        public long Id { get; set; } = DefaultValueMaps.DefaultId;
        public int VersionNo { get; set; } = 0;
        public int pageNumber { get; set; } = DefaultValueMaps.pageNumber;
        public int pageSize { get; set; } = DefaultValueMaps.pageSize;
        public long DocumentLibraryPolicyId { get; set; } = DefaultValueMaps.DefaultId;

       
    }
}
