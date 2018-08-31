using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Core.DataAccessObjects
{
    class RaceDAO : DataAccessObject
    {
        public RaceDAO()
        {
            RaceDrivers = new HashSet<RaceDriverDAO>();
        }

        public DateTime EventDate { get; set; }

        public string EventLocation { get; set; }

        public ICollection<RaceDriverDAO> RaceDrivers { get; set; }
    }
}