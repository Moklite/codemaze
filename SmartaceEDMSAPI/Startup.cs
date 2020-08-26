using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
//using Abp.AspNetCore;
//using Abp.AspNetCore.Mvc.Antiforgery;
using Abp.Dependency;
using Abp.Extensions;
using Abp.Json;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using SmartaceEDMS.API.Application;
using SmartaceEDMS.API.Data;
using StackExchange.Redis;

namespace SmartaceEDMSAPI
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";

        private const string _apiVersion = "v1";

        //private readonly IConfigurationRoot _appConfiguration;

        public Startup(IConfiguration configuration)

        {
            Configuration = configuration;
        }
        //public Startup(IWebHostEnvironment env)
        //{
        //    _appConfiguration = env.GetAppConfiguration();
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionMultiplexer = ConnectionMultiplexer.Connect(Configuration["redis:connectionString"]);
            //var database = connectionMultiplexer.GetDatabase(0);
            //services.AddScoped(_ => database);

            services.AddDbContext<EDMSAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            //  services.AddDbContext<EDMSAppContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("Default"),
            //x => x.MigrationsAssembly("SmartaceEDMS.API.Data")));
           

            //services.AddControllersWithViews(
            //    options =>
            //    {
            //        options.Filters.Add(new AbpAutoValidateAntiforgeryTokenAttribute());
            //    }
            //).AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new AbpMvcContractResolver(IocManager.Instance)
            //    {
            //        NamingStrategy = new CamelCaseNamingStrategy()
            //    };
            //});

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            //}).AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new AbpMvcContractResolver(IocManager.Instance)
            //    {
            //        NamingStrategy = new CamelCaseNamingStrategy()
            //    };
            //});

            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(Configuration.GetConnectionString("Default"));
            });




            services.AddSignalR();

            // Configure CORS for angular2 UI
            services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            Configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(_apiVersion, new OpenApiInfo
                {
                    Version = _apiVersion,
                    Title = "Smartace EDMS API",
                    Description = "EDMS",
                    // uncomment if needed TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "EDMS",
                        Email = string.Empty,
                        Url = new Uri("http://www.smartace.ng/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("http://www.smartace.ng/"),
                    }
                });
                options.DocInclusionPredicate((docName, description) => true);

                // Define the BearerAuth scheme that's in use
                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });

            services.AddCoreServices();
            services.AddControllers();

            // Configure Abp and Dependency Injection
            //return services.AddAbp<EFilingWebHostModule>(
            //    // Configure Log4Net logging
            //    options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
            //        f => f.UseAbpLog4Net().WithConfig("log4net.config")
            //    )
            //);

        }

        private void RegisterServices(IServiceCollection services)
        {

            services.AddTransient<DbContext, SmartaceEDMS.API.Data.EDMSAppContext>();
            services.AddTransient(typeof(SmartaceEDMS.API.Data.EDMSAppContext));
            services.AddTransient(typeof(DbContextOptions<SmartaceEDMS.API.Data.EDMSAppContext>));

            // Adding dependencies from another layers (isolated from Presentation)
            ServiceConnector.AddCoreServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //app.UseAbp(options => { options.UseAbpRequestLocalization = false; }); // Initializes ABP framework.

            app.UseCors(_defaultCorsPolicyName); // Enable CORS!

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            //app.UseAbpRequestLocalization();

            app.UseHangfireServer();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireDashboardAuthorizationFilter() }
            });
            //app.UseMiddleware<TokenManagerMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHub<AbpCommonHub>("/signalr");
                //endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}"); 
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            //app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{_apiVersion}/swagger.json", "EDMS");
            });

            ////// Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            //app.UseSwaggerUI(options =>
            //{
            //    // specifying the Swagger JSON endpoint.
            //    options.SwaggerEndpoint($"/swagger/{_apiVersion}/swagger.json", $"EDMS API {_apiVersion}");
            //    options.IndexStream = () => Assembly.GetExecutingAssembly()
            //        .GetManifestResourceStream("EDMS.Web.Host.wwwroot.swagger.ui.index.html");
            //    options.DisplayRequestDuration(); // Controls the display of the request duration (in milliseconds) for "Try it out" requests.  
            //});
        }
    }
}
