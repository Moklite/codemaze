using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLinkLog : BaseClass
    {
        public long DocumentLinkId { get; set; }
        public DateTime DateViewed { get; set; }
        public string OtherInfo { get; set; }
        public string IPAddress { get; set; }

    }
}
