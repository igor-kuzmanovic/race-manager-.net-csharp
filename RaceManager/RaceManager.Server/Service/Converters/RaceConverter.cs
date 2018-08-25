using RaceManager.Server.DataAccess.Core.Domain;
using RaceManager.Server.Service.Core.Converters;
using RaceManager.Server.Service.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.Service.Converters
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