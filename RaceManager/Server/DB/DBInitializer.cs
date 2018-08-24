using System.Data.Entity;

namespace Server
{
    class DBInitializer : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            context.Users.AddOrUpdate(new User() { Id = 1, Username = "admin", Password = "admin", IsAdmin = true });

            base.Seed(context);
        }
    }
}
