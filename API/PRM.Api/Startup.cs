using System;
using System.Linq;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using PRM.Api.Config;
using PRM.Bl.Validators;
using PRM.Core.Models;
using PRM.Model.Contexts.PRM;
using PRM.Model.IoC;
using PRM.Services.IoC;
using Microsoft.OpenApi.Models;
namespace PRM.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Adding Settings Sections
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<SerilogSettings>(Configuration.GetSection("SerilogSettings"));
            #endregion

            #region OData
            services.AddOData();
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
            #endregion

            #region CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllPolicy",
                      builder =>
                      {
                          builder
                                 .AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowCredentials();
                          builder.SetIsOriginAllowed(x => true);

                      });
            });
            #endregion

            #region IoC Registry
            services.AddModelRegistry();
            services.AddServicesRegistry();
            #endregion

            #region DbContext Configuration
            string myAppDbContextConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PRMDbContext>(op => op.UseSqlServer(myAppDbContextConnection), ServiceLifetime.Transient);
            #endregion

            #region Adding External Libs
            // Serilog Register 
            services.AddSerilog(Configuration);
            // AutoMapper Register
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // Swagger Register 
            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Permission Request Manager - API"
                });
            });
            #endregion

            #region Api config
            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PermissionTypeValidator>());
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "PRM - API v1";
               
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRM - API v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AllowAllPolicy");

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                routeBuilder.EnableDependencyInjection();
            });
        }
    }
}
