using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Service;

namespace Server
{
    class UserService : IUserService
    {
        public IEnumerable<UserDTO> GetAll(string securityToken)
        {
            throw new NotImplementedException();
        }

        public UserDTO Get(string securityToken, int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(string securityToken, UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public bool Update(string securityToken, UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string securityToken, int id)
        {
            throw new NotImplementedException();
        }
    }
}
