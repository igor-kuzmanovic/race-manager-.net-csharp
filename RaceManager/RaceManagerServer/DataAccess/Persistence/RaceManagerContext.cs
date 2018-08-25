using RaceManagerServer.DataAccess.Core;
using RaceManagerServer.DataAccess.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RaceManagerServer.DataAccess.Persistence
{
    class RaceManagerContext : DbContext
    {
        public RaceManagerContext() : base("RaceManagerDb") { }

        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
    }
}