using System.Data.Entity;

namespace Server
{
    class Context : DbContext
    {
        public Context() : base("RaceManagerDbConnection")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<User> Vehicles { get; set; }
        public object Vehicle { get; internal set; }
    }
}
