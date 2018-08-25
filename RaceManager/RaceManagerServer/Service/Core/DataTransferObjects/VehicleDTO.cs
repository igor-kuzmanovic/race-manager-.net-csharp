using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RaceManagerServer.Service.Core.DataTransferObjects
{
    [DataContract]
    public class VehicleDTO
    {
        public VehicleDTO() { }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Manufacturer { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public double EngineHorsepower { get; set; }

        [DataMember]
        public double EngineDisplacement { get; set; }
    }
}