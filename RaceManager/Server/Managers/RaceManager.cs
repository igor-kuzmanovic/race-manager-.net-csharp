using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class RaceManager
    {
        public static RaceManager Instance { get; } = new RaceManager();

        static RaceManager() { }

        private RaceManager() { }

        public Race GetRaceById(int id)
        {
            using (var context = new Context())
            {
                return context.Races.FirstOrDefault(r => r.Id == id);
            }
        }

        public IEnumerable<Race> GetAllRaces()
        {
            using (var context = new Context())
            {
                return context.Races.ToList();
            }
        }

        public int InsertRace(Race race)
        {
            using (var context = new Context())
            {
                context.Races.Add(race);
                context.SaveChanges();
                return race.Id;
            }
        }

        public bool UpdateRace(Race race)
        {
            using (var context = new Context())
            {
                var oldRace = GetRaceById(race.Id);

                if (oldRace == null)
                    return false;

                oldRace.EventDate = race.EventDate;
                oldRace.EventLocation = race.EventLocation;
                oldRace.Drivers = race.Drivers;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteRace(int id)
        {
            using (var context = new Context())
            {
                var race = GetRaceById(id);

                if (race == null)
                    return false;

                context.Races.Remove(race);
                context.SaveChanges();
                return true;
            }
        }
    }
}
