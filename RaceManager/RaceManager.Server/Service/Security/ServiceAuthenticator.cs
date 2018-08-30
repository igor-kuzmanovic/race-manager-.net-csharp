using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Web;

namespace RaceManager.Server.Service.Security
{
    class ServiceAuthenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "admin" && password != "admin")
                throw new Exception();
        }
    }
}