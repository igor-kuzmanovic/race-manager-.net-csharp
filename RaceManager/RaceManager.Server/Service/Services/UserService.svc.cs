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
    public class UserService : IUserService
    {
        public UserDTO Get(string token, int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return new UserDTO();

                return UserMapper.Instance.Map(uow.Users.Get(id));
            }
        }

        public IEnumerable<UserDTO> GetAll(string token)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return new List<UserDTO>();

                return UserMapper.Instance.Map(uow.Users.GetAll());
            }
        }

        public bool Update(string token, UserDTO userDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                var user = uow.Users.Get(userDTO.Id);
                user.Username = userDTO.Username;
                user.Password = userDTO.Password;
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.SecurityToken = userDTO.SecurityToken;
                user.IsAdmin = userDTO.IsAdmin;
                uow.Complete();
                return true;
            }
        }

        public bool Add(string token, UserDTO userDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                uow.Users.Add(UserMapper.Instance.Map(userDTO));
                uow.Complete();
                return true;
            }
        }

        public bool Remove(string token, int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                uow.Users.Remove(id);
                uow.Complete();
                return true;
            }
        }
    }
}
