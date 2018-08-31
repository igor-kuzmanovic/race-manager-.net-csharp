using RaceManager.Server.DataAccess.Core;
using RaceManager.Server.DataAccess.Core.Repositories;
using RaceManager.Server.DataAccess.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Persistence
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly RaceManagerDbContext _context;

        public UnitOfWork(RaceManagerDbContext context)
        {
            _context = context;
            Races = new RaceRepository(_context);
            Drivers = new DriverRepository(_context);
            Vehicles = new VehicleRepository(_context);
            Users = new UserRepository(_context);
        }

        public IRaceRepository Races { get; private set; }
        public IDriverRepository Drivers { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }
        public IUserRepository Users { get; private set; }

        public bool Complete()
        {
            try
            {
                if (_context.SaveChanges() <= 0)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}