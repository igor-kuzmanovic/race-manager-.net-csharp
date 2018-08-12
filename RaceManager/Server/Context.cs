using System.Data.Entity;

namespace Server
{
    class Context : DbContext
    {
        public Context() : base("RaceManagerDbConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
