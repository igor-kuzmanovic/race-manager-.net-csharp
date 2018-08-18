using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Service;

namespace Server
{
    class VehicleService : IVehicleService
    {
        public IEnumerable<VehicleDTO> GetAll(string securityToken)
        {
            throw new NotImplementedException();
        }

        public VehicleDTO Get(string securityToken, int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(string securityToken, VehicleDTO vehicleDTO)
        {
            throw new NotImplementedException();
        }

        public bool Update(string securityToken, VehicleDTO vehicleDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string securityToken, int id)
        {
            throw new NotImplementedException();
        }
    }
}
