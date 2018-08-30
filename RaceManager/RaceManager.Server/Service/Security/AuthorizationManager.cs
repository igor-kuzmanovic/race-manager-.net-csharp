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
        public static AuthorizationManager Instance { get; } = new AuthorizationManager();

        static AuthorizationManager() { }

        private AuthorizationManager() { }

        public bool Authorize(IUnitOfWork uow, string securityToken, bool shouldBeAdmin)
        {
            var user = uow.Users.Find(u => u.SecurityToken == securityToken);

            if (user == null)
                return false;

            if (shouldBeAdmin != user.IsAdmin)
                return false;

            return true;
        }
    }
}