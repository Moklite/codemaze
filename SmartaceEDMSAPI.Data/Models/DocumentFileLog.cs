using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentFileLog
    {
        public long Id { get; set; }
        public long DocumentFileId { get; set; }
        public long AccessModeId { get; set; }
        public long ActorId { get; set; }
        public DateTime Timestamp { get; set; }
        public int VersionNo { get; set; }
        public string OtherInfo { get; set; }
        public string IPAddress { get; set; }
    }

}
