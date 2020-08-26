using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class AuditLog : BaseClass
    {
      
        public DateTime Timestamp { get; set; }
        public string Domain { get; set; }
        public string ItemId { get; set; }
        public string JsonVal { get; set; }
        public string TextVal { get; set; }
        public bool IsJson { get; set; }
    }
}