using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
