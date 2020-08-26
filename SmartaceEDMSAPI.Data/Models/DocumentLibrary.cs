using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLibrary : BaseClass
    {
        public long DocumentLibraryTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ParentDocumentLibraryId { get; set; } 
        public long DocumentLibraryPolicyId { get; set; }



        public virtual DocumentLibraryType DocumentLibraryType { get; set; }
    }
}
