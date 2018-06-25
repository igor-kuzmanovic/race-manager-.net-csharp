using Server.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database.Access
{
    class Context : DbContext
    {
        public Context() : base("RaceManagerDbConnection")
        {
        }

        public DbSet<Race> Races { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
