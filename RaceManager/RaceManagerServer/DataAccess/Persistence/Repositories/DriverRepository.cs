using RaceManagerServer.DataAccess.Core.Domain;
using RaceManagerServer.DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManagerServer.DataAccess.Persistence.Repositories
{
    class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public DriverRepository(RaceManagerContext context) : base(context) { }
    }
}