using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLibraryVersion : BaseClass
    {
        public long DocumentFileId { get; set; }
        public string FileExt { get; set; }
        public decimal FileSize { get; set; }  //in kilobytes
        public long StorageTypeId { get; set; }
        public string StorageURLPath { get; set; }
        public int VersionNo { get; set; }
        public string AccessCode { get; set; }
    }
}
