using Service;
using System.Linq;

namespace Server
{
    class UserMapper : BaseMapper<User, UserDTO>
    {
        public static UserMapper Instance { get; } = new UserMapper();

        static UserMapper() { }

        private UserMapper() { }

        public override User Map(UserDTO userDTO)
        {
            var user = new User();

            user.Id = userDTO.Id;
            user.Username = userDTO.Username;
            user.Password = userDTO.Password;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.IsAdmin = userDTO.IsAdmin;
            user.Token = userDTO.Token;

            return user;
        }

        public override UserDTO Map(User user)
        {
            var userDTO = new UserDTO();

            userDTO.Id = user.Id;
            userDTO.Username = user.Username;
            userDTO.Password = user.Password;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.IsAdmin = user.IsAdmin;
            userDTO.Token = user.Token;

            return userDTO;
        }
    }
}
