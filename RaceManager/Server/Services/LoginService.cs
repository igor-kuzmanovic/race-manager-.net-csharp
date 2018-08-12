using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class LoginService : ILoginService
    {
        public LoginDTO Login(string username, string password)
        {
            var user = UserRepository.Instance.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found: " + username);
                return new LoginDTO();
            }

            if (user.Password != password)
            {
                Console.WriteLine("Incorrect password: " + username);
                return new LoginDTO();
            }

            var loginDTO = new LoginDTO();
            loginDTO.Id = user.Id;
            loginDTO.IsAdmin = user.IsAdmin;

            string generatedToken;
            IEnumerable<string> tokens;

            do
            {
                generatedToken = Guid.NewGuid().ToString();
                tokens = UserRepository.Instance.GetAllTokens();
                Console.WriteLine("Generated token: " + generatedToken);
            } while (UserRepository.Instance.GetUserByToken(generatedToken) != null);

            user.Token = generatedToken;
            UserRepository.Instance.UpdateUser(user);
            Console.WriteLine("Logged in: " + username);

            loginDTO.Token = user.Token;
            return loginDTO;
        }

        public void Logout(string token)
        {
            var user = UserRepository.Instance.GetUserByToken(token);

            if (user == null)
            {
                Console.WriteLine("User not found: " + token);
                return;
            }

            user.Token = string.Empty;
            UserRepository.Instance.UpdateUser(user);
            Console.WriteLine("Logged out: " + user.Username);
        }
    }
}
