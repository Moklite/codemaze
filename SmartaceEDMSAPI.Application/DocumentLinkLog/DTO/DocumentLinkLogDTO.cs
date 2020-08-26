using SmartaceEDMS.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application.DocumentLinkLog.DTO
{
    public class DocumentLinkLogDTO : BaseClass
    {
        public long DocumentLinkId { get; set; }
        public DateTime DateViewed { get; set; }
        public string OtherInfo { get; set; }
        public string IPAddress { get; set; }
    }
}
