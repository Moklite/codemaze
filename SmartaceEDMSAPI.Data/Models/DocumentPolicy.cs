using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentPolicy : BaseClass
    {
        public string Name { get; set; }
    }

    public class DocumentPolicySetting
    {
        public long Id { get; set; }
        public long DocumentPolicyId { get; set; }
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
        public string ValueType { get; set; }  //NUMBER, TEXT, DATE
    }

    public class DocumentPolicyFileExtensions
    {
        public long Id { get; set; }
        public long DocumentPolicyId { get; set; }
        public long FileExtensionId { get; set; }
    }
}
