namespace Server
{
    class AuthorizationManager
    {
        public static AuthorizationManager Instance { get; } = new AuthorizationManager();

        static AuthorizationManager() { }

        private AuthorizationManager() { }

        public bool Authorize(string securityToken, bool shouldBeAdmin)
        {
            var user = UserDBManager.Instance.Find(u => u.Token == securityToken);

            if (user == null)
                return false;

            if (shouldBeAdmin && !user.IsAdmin)
                return false;

            return true;
        }
    }
}
