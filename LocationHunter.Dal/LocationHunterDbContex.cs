using LocationHunter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) 
            {
                return;
            }

            optionsBuilder.UseNpgsql("Host=locationHunter_host;Database=locationHunter_db;UserName=owner;Password=locationHunter_owner_psswd");
        }
    }
}
