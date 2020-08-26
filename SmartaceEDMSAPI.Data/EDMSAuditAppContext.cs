using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartaceEDMS.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SmartaceEDMS.API.Data
{
    public partial class EDMSAuditAppContext : DbContext
    {
        public EDMSAuditAppContext(DbContextOptions<EDMSAuditAppContext> options) : base(options)
        {
            //Database.Migrate();

        }

        public EDMSAuditAppContext()
        {

        }

        public IConfiguration Configuration { get; }

        #region Audit Related Tables
        public virtual  DbSet<AuditLog> AuditLogs { get; set; }
       

        #endregion

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            // this will be corrected later

            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=EdmsAuditDB; Trusted_Connection=True;");


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


           
        }


    }
}
