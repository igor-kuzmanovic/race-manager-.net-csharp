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

namespace RaceManager.Server.Service.Services
{
    public class VehicleService : IVehicleService
    {
        public VehicleDTO Get(int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                return VehicleMapper.Instance.Map(uow.Vehicles.Get(id));
            }
        }

        public IEnumerable<VehicleDTO> GetAll()
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                return VehicleMapper.Instance.Map(uow.Vehicles.GetAll());
            }
        }

        public void Update(VehicleDTO vehicleDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                var vehicle = uow.Vehicles.Get(vehicleDTO.Id);
                vehicle.Manufacturer = vehicleDTO.Manufacturer;
                vehicle.Model = vehicleDTO.Model;
                vehicle.Type = vehicleDTO.Type;
                vehicle.EngineHorsepower = vehicleDTO.EngineHorsepower;
                vehicle.EngineDisplacement = vehicleDTO.EngineDisplacement;
                uow.Complete();
            }
        }

        public void Add(VehicleDTO vehicleDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                uow.Vehicles.Add(VehicleMapper.Instance.Map(vehicleDTO));
                uow.Complete();
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                uow.Vehicles.Remove(id);
                uow.Complete();
            }
        }
    }
}
