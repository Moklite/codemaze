using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLink : BaseClass
    {
        public long DocumentFileId { get; set; }
        public long GeneratedById { get; set; }
        public long GeneratedForId { get; set; }
        public bool IsGeneratedForExternalUser { get; set; }
        public string ExternalUserEmail { get; set; }
        public string ExternalUserPhone { get; set; }
        public string AccessCode { get; set; }
        public string MainURL { get; set; }
        public string ShortURL { get; set; }
        public int UseCount { get; set; } //number of times used
        public int MaxUseCount { get; set; } //maximum number of times useable
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
    }



}
