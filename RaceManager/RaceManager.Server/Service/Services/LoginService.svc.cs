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
        public UserDTO LogIn(string username, string password)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    return new UserDTO();

                if (!AuthenticationManager.Instance.Authenticate(username, password))
                    return new UserDTO();

                var user = uow.Users.Find(u => u.Username.ToLower() == username.ToLower());

                if (user == null)
                    return new UserDTO();

                var securityToken = SecurityTokenManager.Instance.GenerateToken(username);

                var userDTO = new UserDTO();
                userDTO.Id = user.Id;
                userDTO.Username = user.Username;
                userDTO.Password = string.Empty;
                userDTO.SecurityToken = securityToken;
                userDTO.IsAdmin = user.IsAdmin;

                user.SecurityToken = securityToken;
                uow.Complete();

                return userDTO;
            }
        }

        public void LogOut(string securityToken)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
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
