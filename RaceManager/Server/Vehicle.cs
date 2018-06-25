using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Vehicle
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public double EngineHorsepower { get; set; }
        public double EngineDisplacement { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
