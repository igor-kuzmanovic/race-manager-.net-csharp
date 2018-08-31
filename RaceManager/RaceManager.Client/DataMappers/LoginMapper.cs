using RaceManager.Client.Core.DataMappers;
using RaceManager.Client.LoginService;
using RaceManager.Client.Models;

namespace RaceManager.Client.DataMappers
{
    class LoginMapper : DataMapper<User, LoginDTO>, ILoginMapper
    {
        private static LoginMapper _instance = null;

        private static readonly object _padlock = new object();

        private LoginMapper() { }

        public static LoginMapper Instance
        {
            get
            {
                lock (_padlock)
                    if (_instance == null)
                        _instance = new LoginMapper();
                return _instance;
            }
        }

        public override User Map(LoginDTO loginDTO)
        {
            var user = new User();

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

        public override LoginDTO Map(User user)
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