using Service;

namespace Server
{
    class LoginService : ILoginService
    {
        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return new UserDTO();

            if (!AuthenticationManager.Instance.Authenticate(username, password))
                return new UserDTO();

            var user = UserDBManager.Instance.Find(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
                return new UserDTO();

            var securityToken = TokenManager.Instance.GenerateToken(username);

            var userDTO = new UserDTO();
            userDTO.Id = user.Id;
            userDTO.Username = user.Username;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.IsAdmin = user.IsAdmin;
            userDTO.Token = securityToken;

            user.Token = securityToken;
            UserDBManager.Instance.Update(user);
 
            return userDTO;
        }

        public void Logout(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return;

            var user = UserDBManager.Instance.Find(u => u.Token == token);

            if (user == null)
                return;

            user.Token = string.Empty;
            UserDBManager.Instance.Update(user);
        }
    }
}
