using RaceManager.Server.DataAccess.Core.DataAccessObjects;
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

        public DbSet<RaceDAO> Races { get; set; }
        public DbSet<RaceDriverDAO> RaceDrivers { get; set; }
        public DbSet<DriverDAO> Drivers { get; set; }
        public DbSet<VehicleDAO> Vehicles { get; set; }
        public DbSet<UserDAO> Users { get; set; }
    }
}