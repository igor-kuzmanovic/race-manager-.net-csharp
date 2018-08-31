using RaceManager.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.Identity
{
    static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string SecurityToken { get; set; }
        public static bool IsAdmin { get; set; }

        public static void LogUserIn(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            FirstName = user.FirstName;
            LastName = user.LastName;
            SecurityToken = user.SecurityToken;
            IsAdmin = user.IsAdmin;
        }

        public static void LogUserOut()
        {
            Id = 0;
            Username = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            SecurityToken = string.Empty;
            IsAdmin = false;
        }
    }
}
