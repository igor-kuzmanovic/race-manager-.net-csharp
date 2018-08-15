using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Server
{
    class RaceManager
    {
        public static RaceManager Instance { get; } = new RaceManager();

        static RaceManager() { }

        private RaceManager() { }

        public Race GetRace(Expression<Func<Race, bool>> predicate)
        {
            using (var context = new Context())
            {
                return context.Races.FirstOrDefault(predicate);
            }
        }

        public IEnumerable<Race> GetRaces(Expression<Func<Race, bool>> predicate)
        {
            using (var context = new Context())
            {
                return context.Races.Where(predicate).ToList();
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
                var oldRace = GetRace(r => r.Id == race.Id);

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
                var race = GetRace(r => r.Id == id);

                if (race == null)
                    return false;

                context.Races.Remove(race);
                context.SaveChanges();
                return true;
            }
        }
    }
}
