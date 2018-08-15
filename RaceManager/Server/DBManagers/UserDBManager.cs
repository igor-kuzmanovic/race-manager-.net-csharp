using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Server
{
    class UserDBManager : BaseDBManager<User>
    {
        public static UserDBManager Instance { get; } = new UserDBManager();

        static UserDBManager() { }

        private UserDBManager() { }

        public override int Insert(User user)
        {
            using (var context = new Context())
            {
                IEnumerable<User> users = GetAll(u => true);

                if (users.Any(u => u.Username.ToLower() == user.Username.ToLower()))
                    return 0;

                context.Users.Add(user);
                context.SaveChanges();
                return user.Id;
            }
        }

        public override bool Update(User user)
        {
            using (var context = new Context())
            {
                var oldUser = Get(u => u.Id == user.Id);

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
    }
}
