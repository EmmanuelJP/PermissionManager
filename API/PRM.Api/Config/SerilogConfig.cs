using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PRM.Core.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM.Api.Config
{
    public static class SerilogConfig
    {
        public static ILogger GetLogger(IConfiguration configuration = null)
        {
            var _settings = configuration.GetSection("SerilogSettings").Get<SerilogSettings>();
            var connectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            string conStr = _settings?.ConnectionStrings ?? connectionStrings.DefaultConnection;

            LoggerConfiguration _loggerConfig = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Logger(x => x.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Warning).WriteTo.File(_settings.FullFilePath + "Warn-{Date}.log"))
                .WriteTo.Logger(x => x.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Error).WriteTo.File(_settings.FullFilePath + "Error-{Date}.log"))
                .WriteTo.Logger(x => x.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Fatal).WriteTo.File(_settings.FullFilePath + "Fatal-{Date}.log"));

            _loggerConfig =  _loggerConfig.WriteTo.MSSqlServer(conStr, sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions {
                TableName = _settings.Table,
                AutoCreateSqlTable = true
            });
            Log.Logger = _loggerConfig.CreateLogger();

            return Log.Logger;
        }
        public static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            var logger = GetLogger(configuration);
            return services.AddLogging(confiruge => confiruge.AddSerilog(logger, dispose: true));
        }
    }
}
