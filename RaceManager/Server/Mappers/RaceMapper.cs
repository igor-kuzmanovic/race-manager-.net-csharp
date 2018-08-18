using Service;
using System.Linq;

namespace Server
{
    class RaceMapper : BaseMapper<Race, RaceDTO>
    {
        public static RaceMapper Instance { get; } = new RaceMapper();

        static RaceMapper() { }

        private RaceMapper() { }

        public override Race Map(RaceDTO raceDTO)
        {
            var race = new Race();

            race.Id = raceDTO.Id;
            race.EventDate = raceDTO.EventDate;
            race.EventLocation = raceDTO.EventLocation;
            race.Drivers = raceDTO.DriverIds.Select(d => new Driver() { Id = d }).ToList();

            return race;
        }

        public override RaceDTO Map(Race race)
        {
            var raceDTO = new RaceDTO();

            raceDTO.Id = race.Id;
            raceDTO.EventDate = race.EventDate;
            raceDTO.EventLocation = race.EventLocation;
            raceDTO.DriverIds = race.Drivers.Select(d => d.Id).ToList();

            return raceDTO;
        }
    }
}
