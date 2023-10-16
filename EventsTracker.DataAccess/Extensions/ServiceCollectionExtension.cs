using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventsTracker.DataAccess.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccessProject(this IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddDbContext<EventsTrackerContext>(
                optionsBuilder => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=soprano490;Database=EventsTracker;")
            );

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
