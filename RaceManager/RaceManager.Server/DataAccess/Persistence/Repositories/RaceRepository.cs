using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Persistence.Repositories
{
    class RaceRepository : Repository<RaceDAO>, IRaceRepository
    {
        public RaceRepository(RaceManagerDbContext context) : base(context) { }

        public override IEnumerable<RaceDAO> GetAll()
        {
            var races = dbSet.ToList();

            foreach (var race in races)
                race.RaceDrivers = _context.RaceDrivers.Where(rd => rd.RaceId == race.Id).ToList();

            return races;
        }
    }
}