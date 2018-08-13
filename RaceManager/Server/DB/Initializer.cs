using System.Data.Entity;

namespace Server
{
    class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            context.Users.Add(new User() { Id = 1, Username = "admin", Password = "admin", IsAdmin = true });

            base.Seed(context);
        }
    }
}
