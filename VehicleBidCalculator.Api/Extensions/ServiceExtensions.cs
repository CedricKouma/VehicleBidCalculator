using VehicleBidCalculator.Application.Services;
using VehicleBidCalculator.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace VehicleBidCalculator.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICalculationService, CalculationService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetVehicleTotalPriceQueryHandler).Assembly));
            return services;
        }
    }
}
