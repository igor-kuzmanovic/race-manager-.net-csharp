using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Core.DataAccessObjects
{
    class VehicleDAO : DataAccessObject
    {
        public VehicleDAO() { }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public double EngineHorsepower { get; set; }

        public double EngineDisplacement { get; set; }

        public DriverDAO Driver { get; set; }

        public int DriverId { get; set; }
    }
}