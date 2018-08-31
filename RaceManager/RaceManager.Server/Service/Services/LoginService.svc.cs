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
using RaceManager.Server.Service.Security;

namespace RaceManager.Server.Service.Services
{
    public class LoginService : ILoginService
    {
        public LoginDTO LogIn(string username, string password)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    return new LoginDTO();

                if (!AuthenticationManager.Instance.Authenticate(uow, username, password))
                    return new LoginDTO();

                var user = uow.Users.Find(u => u.Username.ToLower() == username.ToLower());

                if (user == null)
                    return new LoginDTO();

                var securityToken = SecurityTokenManager.Instance.GenerateToken(uow, username);

                var loginDTO = new LoginDTO();
                loginDTO.Id = user.Id;
                loginDTO.Username = user.Username;
                loginDTO.Password = string.Empty;
                loginDTO.FirstName = user.FirstName;
                loginDTO.LastName = user.LastName;
                loginDTO.SecurityToken = securityToken;
                loginDTO.IsAdmin = user.IsAdmin;

                user.SecurityToken = securityToken;

                if (!uow.Complete())
                    return new LoginDTO();

                return loginDTO;
            }
        }

        public void LogOut(string securityToken)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (string.IsNullOrWhiteSpace(securityToken))
                    return;

                var user = uow.Users.Find(u => u.SecurityToken == securityToken);

                if (user == null)
                    return;

                user.SecurityToken = string.Empty;
                uow.Complete();
            }
        }
    }
}
