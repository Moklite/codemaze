using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{ 
    public class DocumentFileAuthor :BaseClass
    {
        public long Id { get; set; }
        public long DocumentFileId { get; set; }
        public int VersionNo { get; set; }
        public long AuthorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
