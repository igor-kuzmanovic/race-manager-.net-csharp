using RaceManager.Client.Core.Converters;
using RaceManager.Client.RaceService;

namespace RaceManager.Client.Models.Converters
{
    class RaceConverter : Converter<Race, RaceDTO>, IRaceConverter
    {
        public static RaceConverter Instance { get; } = new RaceConverter();

        static RaceConverter() { }

        private RaceConverter() { }

        public override Race Convert(RaceDTO raceDTO)
        {
            var race = new Race();

            race.Id = raceDTO.Id;
            race.EventDate = raceDTO.EventDate;
            race.EventLocation = raceDTO.EventLocation;

            return race;
        }

        public override RaceDTO Convert(Race race)
        {
            var raceDTO = new RaceDTO();

            raceDTO.Id = race.Id;
            raceDTO.EventDate = race.EventDate;
            raceDTO.EventLocation = race.EventLocation;

            return raceDTO;
        }
    }
}