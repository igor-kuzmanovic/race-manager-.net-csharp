using System.Collections.Generic;
using Service;

namespace Server
{
    class UserService : BaseCRUDService<UserDTO, User>, IUserService
    {
        public override IEnumerable<UserDTO> GetAll(string securityToken)
        {
            throw new System.NotImplementedException();
        }

        public override UserDTO Get(string securityToken, int id)
        {
            throw new System.NotImplementedException();
        }

        public override int Insert(string securityToken, UserDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public override bool Update(string securityToken, UserDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(string securityToken, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
