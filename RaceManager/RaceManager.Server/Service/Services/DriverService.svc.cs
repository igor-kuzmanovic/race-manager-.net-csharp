using RaceManager.Server.DataAccess.Persistence;
using RaceManager.Server.Service.DataMappers;
using RaceManager.Server.Service.Core.DataTransferObjects;
using RaceManager.Server.Service.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RaceManager.Server.Service.Security;

namespace RaceManager.Server.Service.Services
{
    public class DriverService : IDriverService
    {
        public DriverDTO Get(string token, int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return new DriverDTO();

                return DriverMapper.Instance.Map(uow.Drivers.Get(id));
            }
        }

        public IEnumerable<DriverDTO> GetAll(string token)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return new List<DriverDTO>();

                return DriverMapper.Instance.Map(uow.Drivers.GetAll());
            }
        }

        public bool Update(string token, DriverDTO driverDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                var driver = uow.Drivers.Get(driverDTO.Id);

                if (driver == null)
                    return false;

                driver.FirstName = driverDTO.FirstName;
                driver.LastName = driverDTO.LastName;
                driver.UMCN = driverDTO.UMCN;

                if (!uow.Complete())
                    return false;

                return true;
            }
        }

        public bool Add(string token, DriverDTO driverDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                uow.Drivers.Add(DriverMapper.Instance.Map(driverDTO));

                if (!uow.Complete())
                    return false;

                return true;
            }
        }

        public bool Remove(string token, int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                var driver = uow.Drivers.Get(id);

                if (driver == null)
                    return false;

                uow.Drivers.Remove(driver);

                if (!uow.Complete())
                    return false;

                return true;
            }
        }
    }
}
