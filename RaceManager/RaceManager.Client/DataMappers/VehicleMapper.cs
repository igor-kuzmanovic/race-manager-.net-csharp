using RaceManager.Client.Core.DataMappers;
using RaceManager.Client.Models;
using RaceManager.Client.VehicleService;

namespace RaceManager.Client.DataMappers
{
    class VehicleMapper : DataMapper<Vehicle, VehicleDTO>, IVehicleMapper
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

        public override Vehicle Map(VehicleDTO vehicleDTO)
        {
            var vehicle = new Vehicle();

            if (vehicleDTO != null)
            {
                vehicle.Id = vehicleDTO.Id;
                vehicle.Manufacturer = vehicleDTO.Manufacturer;
                vehicle.Model = vehicleDTO.Model;
                vehicle.Type = vehicleDTO.Type;
                vehicle.EngineHorsepower = vehicleDTO.EngineHorsepower;
                vehicle.EngineDisplacement = vehicleDTO.EngineDisplacement;
                vehicle.Driver = vehicleDTO.DriverId == 0 ? null : new Driver() { Id = vehicleDTO.DriverId };
            }

            return vehicle;
        }

        public override VehicleDTO Map(Vehicle vehicle)
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
                vehicleDTO.DriverId = vehicle.Driver == null ? 0 : vehicle.Driver.Id;
            }

            return vehicleDTO;
        }
    }
}