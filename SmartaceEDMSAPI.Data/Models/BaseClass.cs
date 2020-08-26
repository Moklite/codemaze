using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class BaseClass : Entity<long>
    {
        public BaseClass()
        {
            DateCreated = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CompanyId { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedById { get; set; }

        public DateTime? DateModified { get; set; }
        public long? ModifiedById { get; set; }
    }
}
