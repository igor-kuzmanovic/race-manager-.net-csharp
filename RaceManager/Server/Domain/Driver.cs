using System.Collections.Generic;

namespace Server
{
    class Driver : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UMCN { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Race> Races { get; set; }
    }
}
