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
    public class VehicleService : IVehicleService
    {
        public VehicleDTO Get(string token, int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return new VehicleDTO();

                return VehicleMapper.Instance.Map(uow.Vehicles.Get(id));
            }
        }

        public IEnumerable<VehicleDTO> GetAll(string token)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return new List<VehicleDTO>();

                return VehicleMapper.Instance.Map(uow.Vehicles.GetAll());
            }
        }

        public bool Update(string token, VehicleDTO vehicleDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                var vehicle = uow.Vehicles.Get(vehicleDTO.Id);

                if (vehicle == null)
                    return false;

                vehicle.Manufacturer = vehicleDTO.Manufacturer;
                vehicle.Model = vehicleDTO.Model;
                vehicle.Type = vehicleDTO.Type;
                vehicle.EngineHorsepower = vehicleDTO.EngineHorsepower;
                vehicle.EngineDisplacement = vehicleDTO.EngineDisplacement;
                vehicle.DriverId = vehicleDTO.DriverId;

                if (!uow.Complete())
                    return false;

                return true;
            }
        }

        public bool Add(string token, VehicleDTO vehicleDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                uow.Vehicles.Add(VehicleMapper.Instance.Map(vehicleDTO));

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

                var vehicle = uow.Vehicles.Get(id);

                if (vehicle == null)
                    return false;

                uow.Vehicles.Remove(vehicle);

                if (!uow.Complete())
                    return false;

                return true;
            }
        }
    }
}
