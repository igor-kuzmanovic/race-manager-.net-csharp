using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.Service.Core.DataMappers;
using RaceManager.Server.Service.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.Service.DataMappers
{
    class VehicleMapper : DataMapper<VehicleDAO, VehicleDTO>, IVehicleMapper
    {
        private static VehicleMapper _instance = null;

        private static readonly object _padlock = new object();

        private VehicleMapper() { }

        public static VehicleMapper Instance
        {
            get
            {
                lock (_padlock)
                    if (_instance == null)
                        _instance = new VehicleMapper();
                return _instance;
            }
        }

        public override VehicleDAO Map(VehicleDTO vehicleDTO)
        {
            var vehicle = new VehicleDAO();

            if (vehicleDTO != null)
            {
                vehicle.Id = vehicleDTO.Id;
                vehicle.Manufacturer = vehicleDTO.Manufacturer;
                vehicle.Model = vehicleDTO.Model;
                vehicle.Type = vehicleDTO.Type;
                vehicle.EngineHorsepower = vehicleDTO.EngineHorsepower;
                vehicle.EngineDisplacement = vehicleDTO.EngineDisplacement;
                vehicle.DriverId = vehicleDTO.DriverId;
            }

            return vehicle;
        }

        public override VehicleDTO Map(VehicleDAO vehicle)
        {
            var vehicleDTO = new VehicleDTO();

            if (vehicle != null)
            {
                vehicleDTO.Id = vehicle.Id;
                vehicleDTO.Manufacturer = vehicle.Manufacturer;
                vehicleDTO.Model = vehicle.Model;
                vehicleDTO.Type = vehicle.Type;
                vehicleDTO.EngineHorsepower = vehicle.EngineHorsepower;
                vehicleDTO.EngineDisplacement = vehicle.EngineDisplacement;
                vehicleDTO.DriverId = vehicle.DriverId;
            }

            return vehicleDTO;
        }
    }
}