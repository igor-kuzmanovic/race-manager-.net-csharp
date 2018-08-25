using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Core.Domain
{
    class Driver : Entity
    {
        public Driver()
        {
            //Vehicles = new HashSet<Vehicle>();
            //Races = new HashSet<Race>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UMCN { get; set; }

        //public virtual ICollection<Vehicle> Vehicles { get; set; }

        //public virtual ICollection<Race> Races { get; set; }
    }
}