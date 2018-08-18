using System.Data.Entity.Migrations;

namespace Server
{
    class DBConfiguration : DbMigrationsConfiguration<DBContext>
    {
        public DBConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
