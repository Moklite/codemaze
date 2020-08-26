using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLibraryRelationship : BaseClass
    {
        public bool IsFile { get; set; }
        public long SourceId { get; set; }
        public long DestinationId { get; set; }
    }
}
