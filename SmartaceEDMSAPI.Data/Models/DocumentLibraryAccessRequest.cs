using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLibraryAccessRequest : BaseClass
    {
        public long DocumentLibraryId { get; set; }
        public long RequestById { get; set; }
        public long Log_Status { get; set; } //1 for pending, 2 for approved, 3 for declined
        public int AccessModeId { get; set; } //Create, Edit, Delete, Update, Check-out, etc
        public virtual AccessMode AccessMode { get; set; } 
        public virtual DocumentLibrary DocumentLibrary { get; set; } 
    }
}
