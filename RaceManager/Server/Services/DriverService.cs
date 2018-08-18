using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Service;

namespace Server
{
    class DriverService : IDriverService
    {
        public IEnumerable<DriverDTO> GetAll(string securityToken)
        {
            throw new NotImplementedException();
        }

        public DriverDTO Get(string securityToken, int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(string securityToken, DriverDTO driverDTO)
        {
            throw new NotImplementedException();
        }

        public bool Update(string securityToken, DriverDTO driverDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string securityToken, int id)
        {
            throw new NotImplementedException();
        }
    }
}
