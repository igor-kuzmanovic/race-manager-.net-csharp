using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Core.DataAccessObjects
{
    class DriverDAO : DataAccessObject
    {
        public DriverDAO()
        {
            Vehicles = new HashSet<VehicleDAO>();
            RaceDrivers = new HashSet<RaceDriverDAO>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UMCN { get; set; }

        public ICollection<VehicleDAO> Vehicles { get; set; }

        public ICollection<RaceDriverDAO> RaceDrivers { get; set; }
    }
}