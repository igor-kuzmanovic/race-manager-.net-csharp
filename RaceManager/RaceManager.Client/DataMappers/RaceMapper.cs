using RaceManager.Client.Core.DataMappers;
using RaceManager.Client.Models;
using RaceManager.Client.RaceService;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RaceManager.Client.DataMappers
{
    class RaceMapper : DataMapper<Race, RaceDTO>, IRaceMapper
    {
        private static RaceMapper _instance = null;

        private static readonly object _padlock = new object();

        private RaceMapper() { }

        public static RaceMapper Instance
        {
            get
            {
                lock (_padlock)
                    if (_instance == null)
                        _instance = new RaceMapper();
                return _instance;
            }
        }

        public override Race Map(RaceDTO raceDTO)
        {
            var race = new Race();

            if (raceDTO != null)
            {
                race.Id = raceDTO.Id;
                race.EventDate = raceDTO.EventDate;
                race.EventLocation = raceDTO.EventLocation;
                race.Drivers = new ObservableCollection<Driver>(raceDTO.DriverIds.ToList().Select(i => new Driver() { Id = i }));
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
                raceDTO.DriverIds = race.Drivers.Select(d => d.Id).ToArray();
            }

            return raceDTO;
        }
    }
}