using System.Collections.Generic;
using Service;

namespace Server
{
    class DriverService : BaseCRUDService<DriverDTO, Driver>, IDriverService
    {
        public override IEnumerable<DriverDTO> GetAll(string securityToken)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new List<DriverDTO>();

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return new List<DriverDTO>();

            var drivers = DriverDBManager.Instance.FindAll(d => true);
            var driverDTOs = DriverMapper.Instance.Map(drivers);

            return driverDTOs;
        }

        public override DriverDTO Get(string securityToken, int id)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new DriverDTO();

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return new DriverDTO();

            if (id <= 0)
                return new DriverDTO();

            var driver = DriverDBManager.Instance.Find(d => d.Id == id);
            var driverDTO = DriverMapper.Instance.Map(driver);

            return driverDTO;
        }

        public override int Insert(string securityToken, DriverDTO driverDTO)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return 0;

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return 0;

            if (driverDTO == null)
                return 0;

            var driver = DriverMapper.Instance.Map(driverDTO);
            var id = DriverDBManager.Instance.Insert(driver);

            return id;
        }

        public override bool Update(string securityToken, DriverDTO driverDTO)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return false;

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return false;

            if (driverDTO == null)
                return false;

            var driver = DriverMapper.Instance.Map(driverDTO);
            var result = DriverDBManager.Instance.Update(driver);

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

            var result = DriverDBManager.Instance.Delete(id);

            return result;
        }
    }
}
