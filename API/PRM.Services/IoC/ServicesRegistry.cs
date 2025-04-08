using Microsoft.Extensions.DependencyInjection;
using PRM.Services.Generic;
using PRM.Services.Services.Example;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Services.IoC
{
    public static class ServicesRegistry
    {
        public static void AddServicesRegistry(this IServiceCollection services)
        {
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IPermissionTypeService, PermissionTypeService>();
        }
    }
}
