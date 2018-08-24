using System;
using System.Collections.Generic;

namespace Server
{
    class Race : BaseEntity
    {
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
