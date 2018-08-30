using RaceManager.Server.DataAccess.Core;
using RaceManager.Server.DataAccess.Persistence;
using RaceManager.Server.Service.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.Service.Security
{
    class SecurityTokenManager : ISecurityTokenManager
    {
        public static SecurityTokenManager Instance { get; } = new SecurityTokenManager();

        static SecurityTokenManager() { }

        private SecurityTokenManager() { }

        public string GenerateToken(IUnitOfWork uow, string username)
        {
            var user = uow.Users.Find(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
                return string.Empty;

            while (true)
            {
                var generatedToken = Guid.NewGuid().ToString();
                var tokens = uow.Users.GetAll().Select(u => u.SecurityToken);

                if (!tokens.Contains(generatedToken))
                    return generatedToken;
            }
        }
    }
}