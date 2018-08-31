using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.Service.Core.DataMappers;
using RaceManager.Server.Service.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.Service.DataMappers
{
    class RaceMapper : DataMapper<RaceDAO, RaceDTO>, IRaceMapper
    {
        public static RaceMapper Instance { get; } = new RaceMapper();

        static RaceMapper() { }

        private RaceMapper() { }

        public override RaceDAO Map(RaceDTO raceDTO)
        {
            var race = new RaceDAO();

            if (raceDTO != null)
            {
                race.Id = raceDTO.Id;
                race.EventDate = raceDTO.EventDate;
                race.EventLocation = raceDTO.EventLocation;
                race.RaceDrivers = new List<RaceDriverDAO>(raceDTO.DriverIds.Select(i => new RaceDriverDAO() { RaceId = race.Id, DriverId = i }));
            }

            return race;
        }

        public override RaceDTO Map(RaceDAO race)
        {
            var raceDTO = new RaceDTO();

            if (race != null)
            {
                raceDTO.Id = race.Id;
                raceDTO.EventDate = race.EventDate;
                raceDTO.EventLocation = race.EventLocation;
                raceDTO.DriverIds = race.RaceDrivers.Select(rd => rd.DriverId).ToList();
            }

            return raceDTO;
        }
    }
}