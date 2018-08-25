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
    public class VehicleService : IVehicleService
    {
        public VehicleDTO Get(int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                return VehicleConverter.Instance.Convert(uow.Vehicles.Get(id));
            }
        }

        public IEnumerable<VehicleDTO> GetAll()
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                return VehicleConverter.Instance.Convert(uow.Vehicles.GetAll());
            }
        }

        public void Update(VehicleDTO vehicleDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
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
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                uow.Vehicles.Add(VehicleConverter.Instance.Convert(vehicleDTO));
                uow.Complete();
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                uow.Vehicles.Remove(id);
                uow.Complete();
            }
        }
    }
}
