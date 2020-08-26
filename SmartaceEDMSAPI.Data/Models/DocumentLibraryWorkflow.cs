using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLibraryWorkflow : BaseClass
    {
        public long DocumentLibraryId { get; set; }
        public string Name { get; set; }
        public bool IsUserDefined { get; set; }
        public bool UseOTP { get; set; }
        public string BPM_WorkflowCode { get; set; } 
        public virtual DocumentLibrary DocumentLibrary { get; set; }
    }

    public class DocumentLibraryWorkflowStep : BaseClass
    {
        public long DocumentLibraryWorkflowId { get; set; } 
        public string Name { get; set; }
        public bool IsUser { get; set; } //true for  user permission, false for system role permission
        public long PermissionId { get; set; }
        public long UserId { get; set; }
        public virtual DocumentLibrary DocumentLibrary { get; set; }
    }
}
