using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class StorageType : BaseClass
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }

   public class StorageTypeSettings
    {
        public long Id { get; set; }
        public long StorageTypeId { get; set; }
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
        public string ValueType { get; set; }  //Number, String, Date
    }
}
