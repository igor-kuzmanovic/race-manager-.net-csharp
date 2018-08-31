using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Core.DataAccessObjects
{
    class RaceDriverDAO
    {
        public RaceDriverDAO() { }

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Race")]
        public int RaceId { get; set; }

        public RaceDAO Race { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Driver")]
        public int DriverId { get; set; }

        public DriverDAO Driver { get; set; }
    }
}