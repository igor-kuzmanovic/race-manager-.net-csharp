using System.Collections.Generic;
using Service;

namespace Server
{
    class UserService : BaseCRUDService<UserDTO, User>, IUserService
    {
        public override IEnumerable<UserDTO> GetAll(string securityToken)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new List<UserDTO>();

            if (AuthorizationManager.Instance.Authorize(securityToken, true))
                return new List<UserDTO>();

            var users = UserDBManager.Instance.FindAll(u => true);
            var userDTOs = UserMapper.Instance.Map(users);

            return userDTOs;
        }

        public override UserDTO Get(string securityToken, int id)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new UserDTO();

            if (AuthorizationManager.Instance.Authorize(securityToken, true))
                return new UserDTO();

            if (id <= 0)
                return new UserDTO();

            var user = UserDBManager.Instance.Find(u => u.Id == id);
            var userDTO = UserMapper.Instance.Map(user);

            return userDTO;
        }

        public override int Insert(string securityToken, UserDTO userDTO)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return 0;

            if (AuthorizationManager.Instance.Authorize(securityToken, true))
                return 0;

            if (userDTO == null)
                return 0;

            var user = UserMapper.Instance.Map(userDTO);
            var id = UserDBManager.Instance.Insert(user);

            return id;
        }

        public override bool Update(string securityToken, UserDTO userDTO)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return false;

            if (AuthorizationManager.Instance.Authorize(securityToken, true))
                return false;

            if (userDTO == null)
                return false;

            var user = UserMapper.Instance.Map(userDTO);
            var result = UserDBManager.Instance.Update(user);

            return result;
        }

        public override bool Delete(string securityToken, int id)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return false;

            if (AuthorizationManager.Instance.Authorize(securityToken, true))
                return false;

            if (id <= 0)
                return false;

            var result = UserDBManager.Instance.Delete(id);

            return result;
        }
    }
}
