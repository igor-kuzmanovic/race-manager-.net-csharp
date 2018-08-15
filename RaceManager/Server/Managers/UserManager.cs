using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class UserManager
    {
        public static UserManager Instance { get; } = new UserManager();

        static UserManager() { }

        private UserManager() { }

        public User GetUserById(int id)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(u => u.Id == id);
            }
        }

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

        public IEnumerable<User> GetAllUsers()
        {
            using (var context = new Context())
            {
                return context.Users.ToList();
            }
        }

        public IEnumerable<string> GetAllTokens()
        {
            using (var context = new Context())
            {
                return context.Users.Select(u => u.Token).ToList();
            }
        }

        public int InsertUser(User user)
        {
            using (var context = new Context())
            {
                IEnumerable<User> users = GetAllUsers();

                if (users.Any(u => u.Username.ToLower() == user.Username.ToLower()))
                    return 0;

                context.Users.Add(user);
                context.SaveChanges();
                return user.Id;
            }
        }

        public bool UpdateUser(User user)
        {
            using (var context = new Context())
            {
                var oldUser = GetUserById(user.Id);

                if (oldUser == null)
                    return false;

                oldUser.Username = user.Username;
                oldUser.Password = user.Password;
                oldUser.IsAdmin = user.IsAdmin;
                oldUser.Token = user.Token;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteUser(int id)
        {
            using (var context = new Context())
            {
                var user = GetUserById(id);

                if (user == null)
                    return false;

                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
        }
    }
}
