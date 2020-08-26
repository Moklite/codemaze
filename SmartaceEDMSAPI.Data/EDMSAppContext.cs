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
    public partial class EDMSAppContext : DbContext
    {
        public EDMSAppContext(DbContextOptions<EDMSAppContext> options) : base(options)
        {
            //Database.Migrate();

        }

        public EDMSAppContext()
        {

        }

        public IConfiguration Configuration { get; }

        #region Document Related Tables
        public virtual  DbSet<DocumentFileAuthor> DocumentFileAuthors { get; set; }
        public virtual DbSet<DocumentFileLog> DocumentFileLogs { get; set; }
        public virtual  DbSet<DocumentLibrary> DocumentLibraries { get; set; }
        public virtual DbSet<DocumentLibraryAccessRequest> DocumentLibraryAccessRequests { get; set; }
        public virtual DbSet<DocumentLibraryFile> DocumentLibraryFiles { get; set; }
        public virtual  DbSet<DocumentLibraryMetadata> DocumentLibraryMetadatas { get; set; }
        public virtual DbSet<DocumentLibraryPermission> DocumentLibraryPermissions { get; set; }
        public virtual DbSet<DocumentLibraryRelationship> DocumentLibraryRelationships { get; set; }
        public virtual DbSet<DocumentLibraryType> DocumentLibraryTypes { get; set; }
        public virtual DbSet<DocumentLibraryVersion> DocumentLibraryVersions { get; set; }
        public virtual DbSet<DocumentLibraryWorkflow> DocumentLibraryWorkflows { get; set; }
        public virtual DbSet<DocumentLink> DocumentLinks { get; set; }
        public virtual DbSet<DocumentLinkLog> DocumentLinkLogs { get; set; }
        public virtual DbSet<DocumentLinkSetting> DocumentLinkSettings { get; set; }
        public virtual DbSet<DocumentObserver> DocumentObservers { get; set; }
        public virtual DbSet<DocumentPolicy> DocumentPolicies { get; set; }
        public virtual  DbSet<MetaDataDictionary> MetaDataDictionaries { get; set; }
        public virtual  DbSet<StorageType> StorageTypes { get; set; }


        
        

        #endregion

        #region Global Options Related Tables
        public virtual DbSet<GlobalOption> GlobalOptions { get; set; }
       
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (optionsBuilder.IsConfigured)
            //{
            //    base.OnConfiguring(optionsBuilder);
            //    return;
            //}

            //string pathToContentRoot = Directory.GetCurrentDirectory();
            //string json = Path.Combine(pathToContentRoot, "appsettings.json");

            //if (!File.Exists(json))
            //{
            //    string pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            //    pathToContentRoot = Path.GetDirectoryName(pathToExe);
            //}

            //IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
            //    .SetBasePath(pathToContentRoot)
            //    .AddJsonFile("appsettings.json");

            //IConfiguration configuration = configurationBuilder.Build();

            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

            //base.OnConfiguring(optionsBuilder);

            //var config = new ConfigurationBuilder()
            //              .SetBasePath(Directory.GetCurrentDirectory())
            //              .AddJsonFile("appsettings.json", optional: false)
            //              .Build();



            //var connect = config.GetSection("Default").Get<List<string>>().FirstOrDefault();
            //optionsBuilder.UseSqlServer(connect);
            // this will be corrected later

           optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=EdmsDB; Trusted_Connection=True;");


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


           
        }


    }
}
