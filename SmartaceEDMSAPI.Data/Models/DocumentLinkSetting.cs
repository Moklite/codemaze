using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLinkSetting : BaseClass
    {
        public long DocumentLinkId { get; set; }
        public int AccessModeId { get; set; }
    }
}
