using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentObserver : BaseClass
    {  
        public long DocumentFileId { get; set; }
        public long DocumentLibraryId { get; set; }
        public string Metadata { get; set; }
        public long ObserverId { get; set; } 
    }

}
