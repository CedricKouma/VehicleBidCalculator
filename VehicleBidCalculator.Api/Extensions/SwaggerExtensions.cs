using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace VehicleBidCalculator.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VehicleBidCalculator API", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehicleBidCalculator API v1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
