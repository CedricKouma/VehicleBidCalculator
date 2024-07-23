using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VehicleBidCalculator.Api.Extensions
{
    public static class LoggingExtensions
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        {
            services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
            });

            return services;
        }
    }
}
