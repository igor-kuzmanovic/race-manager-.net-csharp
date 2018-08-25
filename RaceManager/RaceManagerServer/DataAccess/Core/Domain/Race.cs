using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManagerServer.DataAccess.Core.Domain
{
    class Race : Entity
    {
        public Race()
        {
            //Drivers = new HashSet<Driver>();
        }

        public DateTime EventDate { get; set; }

        public string EventLocation { get; set; }

        //public virtual ICollection<Driver> Drivers { get; set; }
    }
}