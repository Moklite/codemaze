using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application
{
    public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {

            var httpContext = context.GetHttpContext();

            // Allow all authenticated users to see the Dashboard (potentially dangerous).
            return true; //httpContext.User.Identity.IsAuthenticated;

        }
    }
}
