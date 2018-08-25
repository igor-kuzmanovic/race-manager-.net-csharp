using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RaceManager.Server.Service.Core.DataTransferObjects
{
    [DataContract]
    public class RaceDTO
    {
        public RaceDTO() { }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime EventDate { get; set; }

        [DataMember]
        public string EventLocation { get; set; }
    }
}