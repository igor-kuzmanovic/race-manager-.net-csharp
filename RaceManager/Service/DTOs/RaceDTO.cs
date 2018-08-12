using System;
using System.Collections.Generic;

namespace Service
{
    public class RaceDTO
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public List<int> DriverIds { get; set; }
    }
}