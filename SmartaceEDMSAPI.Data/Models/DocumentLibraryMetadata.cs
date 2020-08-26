using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLibraryMetadata
    {
        public long Id { get; set; }
        public long DocumentFileId { get; set; }
        public string MetadataList { get; set; }  //technology||agriculture||realestate||
    }
}
