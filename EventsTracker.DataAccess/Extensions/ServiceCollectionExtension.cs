using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventsTracker.DataAccess.Extensions
{
    public static class ServiceCollectionExtension
    {
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
