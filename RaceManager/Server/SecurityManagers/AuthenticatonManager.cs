namespace Server
{
    class AuthenticationManager
    {
        public static AuthenticationManager Instance { get; } = new AuthenticationManager();

        static AuthenticationManager() { }

        private AuthenticationManager() { }

        public bool Authenticate(string username, string password)
        {
            var user = UserDBManager.Instance.Get(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
                return false;

            if (user.Password != password)
                return false;

            return true;
        }
    }
}
