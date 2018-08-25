using RaceManager.Server.DataAccess.Persistence;
using RaceManager.Server.Service.Converters;
using RaceManager.Server.Service.Core.DataTransferObjects;
using RaceManager.Server.Service.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaceManager.Server.Service.Services
{
    public class DriverService : IDriverService
    {
        public DriverDTO Get(int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                return DriverConverter.Instance.Convert(uow.Drivers.Get(id));
            }
        }

        public IEnumerable<DriverDTO> GetAll()
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                return DriverConverter.Instance.Convert(uow.Drivers.GetAll());
            }
        }

        public void Update(DriverDTO driverDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                var driver = uow.Drivers.Get(driverDTO.Id);
                driver.FirstName = driverDTO.FirstName;
                driver.LastName = driverDTO.LastName;
                driver.UMCN = driverDTO.UMCN;
                uow.Complete();
            }
        }

        public void Add(DriverDTO driverDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                uow.Drivers.Add(DriverConverter.Instance.Convert(driverDTO));
                uow.Complete();
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                uow.Drivers.Remove(id);
                uow.Complete();
            }
        }
    }
}
