using System.Data.Entity;

namespace Server
{
    class DBContext : DbContext
    {
        public DBContext() : base("RaceManagerDbConnection")
        {
            Database.SetInitializer(new DBInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
