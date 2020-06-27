using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LocationHunter.Dal.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDefaultDbContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<LocationHunterDbContex>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }

        public static void ApplyDatabaseMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app
                .ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            var context = serviceScope.ServiceProvider.GetService<LocationHunterDbContex>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
