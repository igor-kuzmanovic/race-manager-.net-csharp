using RaceManager.Server.DataAccess.Core;
using RaceManager.Server.DataAccess.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Persistence
{
    class RaceManagerContext : DbContext
    {
        public RaceManagerContext() : base("RaceManagerDb") { }

        public DbSet<Race> Races { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}