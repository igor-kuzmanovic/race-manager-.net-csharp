using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RaceManager.Server.Service.Core.DataTransferObjects
{
    [DataContract]
    public class LoginDTO
    {
        public LoginDTO() { }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string SecurityToken { get; set; }

        [DataMember]
        public bool IsAdmin { get; set; }
    }
}