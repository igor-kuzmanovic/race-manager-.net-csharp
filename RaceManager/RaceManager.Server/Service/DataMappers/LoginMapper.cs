using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.Service.Core.DataMappers;
using RaceManager.Server.Service.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.Service.DataMappers
{
    class LoginMapper : DataMapper<UserDAO, LoginDTO>, ILoginMapper
    {
        public static LoginMapper Instance { get; } = new LoginMapper();

        static LoginMapper() { }

        private LoginMapper() { }

        public override UserDAO Map(LoginDTO loginDTO)
        {
            var user = new UserDAO();

            if (loginDTO != null)
            {
                user.Id = loginDTO.Id;
                user.Username = loginDTO.Username;
                user.Password = loginDTO.Password;
                user.FirstName = loginDTO.FirstName;
                user.LastName = loginDTO.LastName;
                user.SecurityToken = loginDTO.SecurityToken;
                user.IsAdmin = loginDTO.IsAdmin;
            }

            return user;
        }

        public override LoginDTO Map(UserDAO user)
        {
            var loginDTO = new LoginDTO();

            if (user != null)
            {
                loginDTO.Id = user.Id;
                loginDTO.Username = user.Username;
                loginDTO.Password = user.Password;
                loginDTO.FirstName = user.FirstName;
                loginDTO.LastName = user.LastName;
                loginDTO.SecurityToken = user.SecurityToken;
                loginDTO.IsAdmin = user.IsAdmin;
            }

            return loginDTO;
        }
    }
}