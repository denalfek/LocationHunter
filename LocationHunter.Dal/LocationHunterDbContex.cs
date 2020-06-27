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
                .UseNpgsql("Server=postgres;Port=5432;Database=locationHunter_db;Username=root;Password=secretPassword");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LocationBuilder());
            builder.Entity<Location>().HasIndex(l => l.Ip);
        }
    }
}
