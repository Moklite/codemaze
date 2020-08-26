using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class DocumentLibraryPermission : BaseClass
    {
        public long DocumentLibraryId { get; set; }
        public int AccessModeId { get; set; } //Create, Edit, Delete, Update, Check-out, etc
        public bool IsUser { get; set; } //true for  user permission, false for system role permission
        public long PermissionId { get; set; }
        public long UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public long? GrantedById { get; set;}

        public virtual AccessMode AccessMode { get; set; }
        public virtual DocumentLibrary DocumentLibrary { get; set; }
    }
}
