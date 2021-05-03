using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Autopal.ASML.Runner.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection SetupServices(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
            var logLevelFromConfiugration = configuration["Logging:LogLevel:Default"];
            if (!Enum.TryParse(logLevelFromConfiugration, out LogLevel logLevel))
                logLevel = LogLevel.Warning;
            services.AddLogging(opt =>
            {
                opt.AddFilter((_, level) => level >= logLevel);
                opt.AddConsole();
            });
            
            return services;
        }
    }
}