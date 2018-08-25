using RaceManagerServer.DataAccess.Core;
using RaceManagerServer.DataAccess.Core.Repositories;
using RaceManagerServer.DataAccess.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManagerServer.DataAccess.Persistence
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly RaceManagerContext _context;

        public UnitOfWork(RaceManagerContext context)
        {
            _context = context;
            Races = new RaceRepository(context);
            Drivers = new DriverRepository(context);
            Vehicles = new VehicleRepository(context);
        }

        public IRaceRepository Races { get; private set; }
        public IDriverRepository Drivers { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}