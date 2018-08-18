using System.Collections.Generic;
using Service;

namespace Server
{
    class VehicleService : BaseCRUDService<VehicleDTO, Vehicle>, IVehicleService
    {
        public override IEnumerable<VehicleDTO> GetAll(string securityToken)
        {
            throw new System.NotImplementedException();
        }

        public override VehicleDTO Get(string securityToken, int id)
        {
            throw new System.NotImplementedException();
        }

        public override int Insert(string securityToken, VehicleDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public override bool Update(string securityToken, VehicleDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(string securityToken, int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
