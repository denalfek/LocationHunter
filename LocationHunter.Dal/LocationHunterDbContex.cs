using LocationHunter.Core.Entities;
using LocationHunter.Dal.ContextBuilders;
using LocationHunter.Dal.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LocationHunter.Dal
{
    public class LocationHunterDbContex : DbContext
    {
        private readonly string _connStr;

        public LocationHunterDbContex() 
        {
        }
        
        public LocationHunterDbContex(DbContextOptions<LocationHunterDbContex> options, DbConnectionExtension dbConnection)
            : base(options)
        {
            _connStr = dbConnection.ConnectionString;
        }

        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder
                .UseNpgsql(_connStr);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LocationBuilder());
            builder.Entity<Location>().HasIndex(l => l.Ip);
        }
    }
}
