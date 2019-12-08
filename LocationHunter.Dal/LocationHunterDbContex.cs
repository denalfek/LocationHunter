using LocationHunter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;

namespace LocationHunter.Dal
{
    public class LocationHunterDbContex : DbContext
    {
        public LocationHunterDbContex() 
        {
            Database.EnsureCreated();
        }
        
        public LocationHunterDbContex(DbContextOptions<LocationHunterDbContex> options) 
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        private const string ConnStr = "Server=127.0.0.1;Database=locationHunter_db;UserName=owner;Password=locationHunter_owner_psswd";

        public void ConnectionOpen()
        {
            new NpgsqlConnection(ConnStr).Open();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) 
            {
                return;
            }

            var connStr = 

            optionsBuilder.UseNpgsql(ConnStr);
        }
    }
}
