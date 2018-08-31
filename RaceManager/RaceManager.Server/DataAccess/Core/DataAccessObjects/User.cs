using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Core.DataAccessObjects
{
    class UserDAO : DataAccessObject
    {
        public UserDAO() { }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecurityToken { get; set; }

        public bool IsAdmin { get; set; }
    }
}