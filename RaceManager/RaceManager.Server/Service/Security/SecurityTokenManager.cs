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
        private static SecurityTokenManager _instance = null;

        private static readonly object _padlock = new object();

        private SecurityTokenManager() { }

        public static SecurityTokenManager Instance
        {
            get
            {
                lock (_padlock)
                    if (_instance == null)
                        _instance = new SecurityTokenManager();
                    return _instance;
            }
        }

        public string GenerateToken(IUnitOfWork uow, string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return string.Empty;

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