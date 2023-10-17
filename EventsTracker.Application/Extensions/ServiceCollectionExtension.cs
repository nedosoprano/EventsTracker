using EventsTracker.DataAccess.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventsTracker.Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationProject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessProject(configuration);
            services.AddScoped<IEventsPerDateService, EventsPerDateService>();

            return services;
        }
    }
}
