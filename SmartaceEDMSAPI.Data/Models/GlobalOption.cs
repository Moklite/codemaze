using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Data.Models
{
    public class GlobalOption : Entity<long>
    {
        public static void ConfigureFluent(ModelBuilder builder)
        {
            builder.Entity<GlobalOption>().HasIndex(x => x.Name);
            //builder.Entity<GlobalOption>().Property(x => x.IsActive).HasDefaultValue(true);
        }
        public string Name { get; set; }
        public string Value { get; set; }
        //public bool? IsActive { get; set; }
    }
}
