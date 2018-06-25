using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database.Models
{
    class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UMCN { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Race> Races { get; set; }
    }
}
