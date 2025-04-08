using Microsoft.Extensions.DependencyInjection;
using PRM.Model.Contexts.PRM;
using PRM.Model.UnitOfWorks;
using PRM.Model.UnitOfWorks.PRM;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Model.IoC
{
    public static class ModelRegistry
    {
        public static void AddModelRegistry(this IServiceCollection services)
        {
            services.AddTransient<IPRMDbContext,PRMDbContext>();
            services.AddScoped<IUnitOfWork<IPRMDbContext>, PRMUnitOfWork>();
        }
    }
}
