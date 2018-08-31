using RaceManager.Server.DataAccess.Core.Domain;
using RaceManager.Server.DataAccess.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Persistence
{
    class RaceManagerDbContext : DbContext
    {
        public RaceManagerDbContext() : base("name=RaceManagerDbConnection")
        {
            Database.SetInitializer(new RaceManagerDbInitializer());
        }

        public DbSet<Race> Races { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}