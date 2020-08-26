using SmartaceEDMS.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application.DocumentLinkSetting.DTO
{
    public class DocumentLinkSettingDTO : BaseClass
    {
        public long DocumentLinkId { get; set; }
        public int AccessModeId { get; set; }
    }
}
