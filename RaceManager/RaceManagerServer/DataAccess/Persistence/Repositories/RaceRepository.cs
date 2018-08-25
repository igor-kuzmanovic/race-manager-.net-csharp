using RaceManagerServer.DataAccess.Core.Domain;
using RaceManagerServer.DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManagerServer.DataAccess.Persistence.Repositories
{
    class RaceRepository : Repository<Race>, IRaceRepository
    {
        public RaceRepository(RaceManagerContext context) : base(context) { }
    }
}