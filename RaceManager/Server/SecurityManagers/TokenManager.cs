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
            string generatedToken;
            IEnumerable<string> tokens;

            do
            {
                generatedToken = Guid.NewGuid().ToString();
                tokens = UserDBManager.Instance.GetAll(u => true).Select(u => u.Token);
            } while (tokens.Contains(generatedToken));

            return generatedToken;
        }
    }
}
