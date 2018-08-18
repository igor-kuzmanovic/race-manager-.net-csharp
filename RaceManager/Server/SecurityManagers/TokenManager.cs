using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class TokenManager
    {
        public static TokenManager Instance { get; } = new TokenManager();

        static TokenManager() { }

        private TokenManager() { }

        public string GenerateToken(string username)
        {
            var user = UserDBManager.Instance.Find(u => u.Username == username);

            if (user == null)
                return string.Empty;

            while (true)
            {
                var generatedToken = Guid.NewGuid().ToString();
                var tokens = UserDBManager.Instance.FindAll(u => true).Select(u => u.Token);

                if (!tokens.Contains(generatedToken))
                    return generatedToken;
            }
        }
    }
}
