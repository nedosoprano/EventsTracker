using EventsTracker.DataAccess.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EventsTracker.DataAccess.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccessProject(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Event>, EventRepository>();

            return services;
        }
    }
}
