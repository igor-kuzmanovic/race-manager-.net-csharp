using System.Collections.Generic;
using Service;

namespace Server
{
    class VehicleService : BaseCRUDService<VehicleDTO, Vehicle>, IVehicleService
    {
        public override IEnumerable<VehicleDTO> GetAll(string securityToken)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new List<VehicleDTO>();

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return new List<VehicleDTO>();

            var vehicles = VehicleDBManager.Instance.FindAll(v => true);
            var vehicleDTOs = VehicleMapper.Instance.Map(vehicles);

            return vehicleDTOs;
        }

        public override VehicleDTO Get(string securityToken, int id)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new VehicleDTO();

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return new VehicleDTO();

            if (id <= 0)
                return new VehicleDTO();

            var vehicle = VehicleDBManager.Instance.Find(v => v.Id == id);
            var vehicleDTO = VehicleMapper.Instance.Map(vehicle);

            return vehicleDTO;
        }

        public override int Insert(string securityToken, VehicleDTO vehicleDTO)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return 0;

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return 0;

            if (vehicleDTO == null)
                return 0;

            var vehicle = VehicleMapper.Instance.Map(vehicleDTO);
            var id = VehicleDBManager.Instance.Insert(vehicle);

            return id;
        }

        public override bool Update(string securityToken, VehicleDTO vehicleDTO)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return false;

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return false;

            if (vehicleDTO == null)
                return false;

            var vehicle = VehicleMapper.Instance.Map(vehicleDTO);
            var result = VehicleDBManager.Instance.Update(vehicle);

            return result;
        }

        public override bool Delete(string securityToken, int id)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return false;

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return false;

            if (id <= 0)
                return false;

            var result = VehicleDBManager.Instance.Delete(id);

            return result;
        }
    }
}
