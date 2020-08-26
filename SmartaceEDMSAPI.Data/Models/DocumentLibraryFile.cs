using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLibraryFile : BaseClass
    {
        public long DocumentLibraryId { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public decimal FileSize { get; set; }  //in kilobytes
        public long StorageTypeId { get; set; }
        public string StorageURLPath { get; set; }
        public int FileStatusId { get; set; }
        public int VersionNo { get; set; }
        public string SerialNo { get; set; }
        public long DocumentLibraryPolicyId { get; set; }
        public long OwnerId { get; set; }
    }


    

    


}
