using RaceManager.Client.Core.DataMappers;
using RaceManager.Client.RaceService;

namespace RaceManager.Client.Models.DataMappers
{
    class RaceMapper : DataMapper<Race, RaceDTO>, IRaceMapper
    {
        public static RaceMapper Instance { get; } = new RaceMapper();

        static RaceMapper() { }

        private RaceMapper() { }

        public override Race Map(RaceDTO raceDTO)
        {
            var race = new Race();

            if (raceDTO != null)
            {
                race.Id = raceDTO.Id;
                race.EventDate = raceDTO.EventDate;
                race.EventLocation = raceDTO.EventLocation;
            }

            return race;
        }

        public override RaceDTO Map(Race race)
        {
            var raceDTO = new RaceDTO();

            if (race != null)
            {
                raceDTO.Id = race.Id;
                raceDTO.EventDate = race.EventDate;
                raceDTO.EventLocation = race.EventLocation;
            }

            return raceDTO;
        }
    }
}