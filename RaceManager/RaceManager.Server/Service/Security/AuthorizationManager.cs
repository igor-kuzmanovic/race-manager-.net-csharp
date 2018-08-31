using RaceManager.Server.DataAccess.Core;
using RaceManager.Server.DataAccess.Persistence;
using RaceManager.Server.Service.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.Service.Security
{
    class AuthorizationManager : IAuthorizationManager
    {
        private static AuthorizationManager _instance = null;

        private static readonly object _padlock = new object();

        private AuthorizationManager() { }

        public static AuthorizationManager Instance
        {
            get
            {
                lock (_padlock)
                    if (_instance == null)
                        _instance = new AuthorizationManager();
                return _instance;
            }
        }

        public bool Authorize(IUnitOfWork uow, string securityToken)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return false;

            var user = uow.Users.Find(u => u.SecurityToken == securityToken);

            if (user == null)
                return false;

            return true;
        }
    }
}