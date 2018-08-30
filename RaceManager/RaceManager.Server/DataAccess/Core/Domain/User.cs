using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Core.Domain
{
    class User : Entity
    {
        public User() { }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecurityToken { get; set; }

        public bool IsAdmin { get; set; }
    }
}