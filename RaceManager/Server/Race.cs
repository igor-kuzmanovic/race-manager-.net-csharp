using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Race : BaseEntity
    {
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
