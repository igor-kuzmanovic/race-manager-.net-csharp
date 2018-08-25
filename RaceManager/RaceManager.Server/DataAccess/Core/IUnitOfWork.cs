using RaceManager.Server.DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Server.DataAccess.Core
{
    interface IUnitOfWork : IDisposable
    {
        IRaceRepository Races { get; }
        IDriverRepository Drivers { get; }
        IVehicleRepository Vehicles { get; }
        int Complete();
    }
}
