using RaceManager.Server.DataAccess.Persistence;
using RaceManager.Server.Service.DataMappers;
using RaceManager.Server.Service.Core.DataTransferObjects;
using RaceManager.Server.Service.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaceManager.Server.Service.Services
{
    public class LoginService : ILoginService
    {
        public string LogIn(string username, string password)
        {
            if (username == "admin" && password == "admin")
                return "1234";
            return string.Empty;
        }

        public void LogOut(string securityToken)
        {
            if (securityToken == "1234")
                return;
        }
    }
}
