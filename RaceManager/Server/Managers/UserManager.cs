using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Server
{
    class UserManager
    {
        public static UserManager Instance { get; } = new UserManager();

        static UserManager() { }

        private UserManager() { }

        public User GetUser(Expression<Func<User, bool>> predicate)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(predicate);
            }
        }

        public IEnumerable<User> GetUsers(Expression<Func<User, bool>> predicate)
        {
            using (var context = new Context())
            {
                return context.Users.Where(predicate).ToList();
            }
        }

        public int InsertUser(User user)
        {
            using (var context = new Context())
            {
                IEnumerable<User> users = GetUsers(u => true);

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
                var oldUser = GetUser(u => u.Id == user.Id);

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
                var user = GetUser(u => u.Id == id);

                if (user == null)
                    return false;

                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
        }
    }
}
