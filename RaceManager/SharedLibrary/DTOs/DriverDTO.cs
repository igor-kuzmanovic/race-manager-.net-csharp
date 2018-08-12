using System.Collections.Generic;

namespace SharedLibrary
{
    class DriverDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UMCN { get; set; }
        public List<int> VehicleIds { get; set; }
        public List<int> RaceIds { get; set; }
    }
}
