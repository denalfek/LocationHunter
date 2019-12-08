using LocationHunter.Core.Entities;
using LocationHunter.Dal.ContextBuilders;
using Microsoft.EntityFrameworkCore;

namespace LocationHunter.Dal
{
    public class LocationHunterDbContex : DbContext
    {
        public LocationHunterDbContex() 
        {
        }
        
        public LocationHunterDbContex(DbContextOptions<LocationHunterDbContex> options) 
            : base(options)
        {
        }

        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) 
            {
                return;
            }

            optionsBuilder
                .UseNpgsql("Server=postgres;Database=locationHunter_db;User ID=postgres;Password=;Port=5432");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LocationBuilder());
            builder.Entity<Location>().HasIndex(l => l.Ip);
        }
    }
}
