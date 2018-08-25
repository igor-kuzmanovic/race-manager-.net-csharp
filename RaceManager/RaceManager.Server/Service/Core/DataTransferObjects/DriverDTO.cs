using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RaceManager.Server.Service.Core.DataTransferObjects
{
    [DataContract]
    public class DriverDTO
    {
        public DriverDTO() { }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string UMCN { get; set; }
    }
}