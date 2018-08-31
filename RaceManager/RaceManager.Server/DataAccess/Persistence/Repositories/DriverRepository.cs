using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Persistence.Repositories
{
    class DriverRepository : Repository<DriverDAO>, IDriverRepository
    {
        public DriverRepository(RaceManagerDbContext context) : base(context) { }
    }
}