using EventsTracker.DataAccess.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventsTracker.Application.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Adds necessary for EventsTracker.Application> project dependencies.
        /// </summary>
        public static IServiceCollection AddApplicationProject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessProject(configuration);
            services.AddScoped<IEventsPerDateService, EventsPerDateService>();

            return services;
        }
    }
}
