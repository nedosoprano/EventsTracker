using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventsTracker.DataAccess.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Adds necessary for EventsTracker.DataAccess> project dependencies.
        /// </summary>
        public static IServiceCollection AddDataAccessProject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddDbContext<EventsTrackerContext>(
                optionsBuilder => optionsBuilder.UseNpgsql(configuration.GetValue<string>("EventsTrackerDbConnectionString"))
            );

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
