using SmartaceEDMS.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application.AuditLog.DTO
{
   public class AuditLogDTO : BaseClass
    {
        public DateTime Timestamp { get; set; }
        public string Domain { get; set; }
        public string ItemId { get; set; }
        public object JsonVal { get; set; }
        public string TextVal { get; set; }
        public bool IsJson { get; set; }
    }


   
}
