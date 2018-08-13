using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class LoginService : ILoginService
    {
        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Empty username or password");
                return new UserDTO();
            }

            var user = UserRepository.Instance.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found: " + username);
                return new UserDTO();
            }

            if (user.Password != password)
            {
                Console.WriteLine("Incorrect password: " + username);
                return new UserDTO();
            }

            var userDTO = new UserDTO();
            userDTO.Id = user.Id;
            userDTO.Username = user.Username;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.IsAdmin = user.IsAdmin;

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

            userDTO.Token = user.Token;
            return userDTO;
        }

        public void Logout(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Empty token");
                return;
            }

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
