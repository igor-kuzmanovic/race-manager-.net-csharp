using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class UserRepository
    {
        public static UserRepository Instance { get; } = new UserRepository();

        public User GetUserByUsername(string username)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
            }
        }

        public User GetUserByToken(string token)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(u => u.Token == token);
            }
        }

        public IEnumerable<string> GetAllTokens()
        {
            using (var context = new Context())
            {
                return context.Users.Select(u => u.Token);
            }
        }

        public void UpdateUser(User user)
        {
            using (var context = new Context())
            {
                var dbUser = context.Users.FirstOrDefault(u => u.Id == user.Id);

                if (dbUser == null)
                    return;

                dbUser.Username = user.Username;
                dbUser.Password = user.Password;
                dbUser.IsAdmin = user.IsAdmin;
                dbUser.Token = user.Token;
                context.SaveChanges();
            }
        }
    }
}
