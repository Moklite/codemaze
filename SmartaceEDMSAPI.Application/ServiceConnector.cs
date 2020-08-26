using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SmartaceEDMS.API.Application.AuditLog.Concrete;
using SmartaceEDMS.API.Application.AuditLog.Interface;
using SmartaceEDMS.API.Application.DocumentLibrary.Concrete;
using SmartaceEDMS.API.Application.DocumentLibrary.Interface;
using SmartaceEDMS.API.Application.DocumentLibraryVersion.Concrete;
using SmartaceEDMS.API.Application.DocumentLibraryVersion.Interface;
using SmartaceEDMS.API.Application.GlobalOptions.Concrete;
using SmartaceEDMS.API.Application.GlobalOptions.Interface;
using SmartaceEDMS.API.Application.SharedServices.Concrete;
using SmartaceEDMS.API.Application.SharedServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application
{
    public static class ServiceConnector
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            //services.AddTransient<TokenManagerMiddleware>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IGlobalOptionService, GlobalOptionService>();
            //services.AddTransient<IMapper, AutoMapper.Ima>();
            services.AddTransient<ICommonServices, CommonServices>();
            services.AddTransient<IAuditLogService, AuditLogService>();
            services.AddTransient<IDocumentLibraryService, DocumentLibraryService>();
            services.AddTransient<IDocumentLibraryVersionService, DocumentLibraryVersionService>();
          

        }
    }
}
