using RaceManager.Server.DataAccess.Persistence;
using RaceManager.Server.Service.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.Service.Security
{
    class AuthenticationManager : IAuthenticationManager
    {
        public static AuthenticationManager Instance { get; } = new AuthenticationManager();

        static AuthenticationManager() { }

        private AuthenticationManager() { }

        public bool Authenticate(string username, string password)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                var user = uow.Users.Find(u => u.Username.ToLower() == username.ToLower());

                if (user == null)
                    return false;

                if (user.Password != password)
                    return false;

                return true;
            }
        }
    }
}