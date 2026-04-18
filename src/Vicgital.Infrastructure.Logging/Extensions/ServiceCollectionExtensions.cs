using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Vicgital.Infrastructure.Logging.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSerilogLogging(this IServiceCollection services, ILogger logger)
        {
            services.AddLogging(configure =>
            {
                configure.AddSerilog(logger);
            });
        }

    }
}
