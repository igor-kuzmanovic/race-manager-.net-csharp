using System.Collections.Generic;
using Service;

namespace Server
{
    class DriverService : BaseCRUDService<DriverDTO, Driver>, IDriverService
    {
        public override IEnumerable<DriverDTO> GetAll(string securityToken)
        {
            throw new System.NotImplementedException();
        }

        public override DriverDTO Get(string securityToken, int id)
        {
            throw new System.NotImplementedException();
        }

        public override int Insert(string securityToken, DriverDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public override bool Update(string securityToken, DriverDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(string securityToken, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
