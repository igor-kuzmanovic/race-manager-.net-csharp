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
    public class UserService : IUserService
    {
        public UserDTO Get(int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                return UserMapper.Instance.Map(uow.Users.Get(id));
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                return UserMapper.Instance.Map(uow.Users.GetAll());
            }
        }

        public void Update(UserDTO userDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                var user = uow.Users.Get(userDTO.Id);
                user.Username = userDTO.Username;
                user.Password = userDTO.Password;
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.SecurityToken = userDTO.SecurityToken;
                user.IsAdmin = userDTO.IsAdmin;
                uow.Complete();
            }
        }

        public void Add(UserDTO userDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                uow.Users.Add(UserMapper.Instance.Map(userDTO));
                uow.Complete();
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                uow.Users.Remove(id);
                uow.Complete();
            }
        }
    }
}
