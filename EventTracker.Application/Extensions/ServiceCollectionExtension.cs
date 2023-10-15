using EventsTracker.Application.Models;
using EventsTracker.DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace EventsTracker.Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationProject(this IServiceCollection services)
        {
            services.AddDataAccessProject();
            services.AddScoped<IService<EventsPerDate>, EventsPerDateService>();

            return services;
        }
    }
}
