using System.Data.Entity.Migrations;

namespace Server
{
    class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Context";
        }

        protected override void Seed(Context context)
        {
            context.Users.Add(new User() { Id = 1, Username = "Admin", Password = "Admin", IsAdmin = true });

            base.Seed(context);
        }
    }
}
