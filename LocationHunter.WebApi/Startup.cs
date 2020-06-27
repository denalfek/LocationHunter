using System.Linq;
using LocationHunter.Dal.Extensions;
using LocationHunter.Dal.Repositories;
using LocationHunter.Dal.Repositories.Interfaces;
using LocationHunter.WebApi.Services;
using LocationHunter.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LocationHunter.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(
                typeof(DbConnectionExtension),
                new DbConnectionExtension()
                {
                    ConnectionString = Configuration.GetConnectionString("DefaultConnection")
                });
            services.AddDefaultDbContext(
                (DbConnectionExtension)services
                    .Single(x => x.ServiceType == typeof(DbConnectionExtension))
                    .ImplementationInstance);
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IIpService, IpService>();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.ApplyDatabaseMigrations();
        }
    }
}
