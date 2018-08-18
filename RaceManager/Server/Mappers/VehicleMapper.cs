using Service;
using System.Linq;

namespace Server
{
    class VehicleMapper : BaseMapper<Vehicle, VehicleDTO>
    {
        public static VehicleMapper Instance { get; } = new VehicleMapper();

        static VehicleMapper() { }

        private VehicleMapper() { }

        public override Vehicle Map(VehicleDTO vehicleDTO)
        {
            var vehicle = new Vehicle();

            vehicle.Id = vehicleDTO.Id;
            vehicle.Manufacturer = vehicleDTO.Manufacturer;
            vehicle.Model = vehicleDTO.Model;
            vehicle.Type = vehicleDTO.Type;
            vehicle.EngineHorsepower = vehicleDTO.EngineHorsepower;
            vehicle.EngineDisplacement = vehicleDTO.EngineDisplacement;
            vehicle.Driver = DriverDBManager.Instance.Find(d => d.Id == vehicleDTO.Id);
            vehicle.DriverId = vehicleDTO.DriverId;

            return vehicle;
        }

        public override VehicleDTO Map(Vehicle vehicle)
        {
            var vehicleDTO = new VehicleDTO();

            vehicleDTO.Id = vehicle.Id;
            vehicleDTO.Manufacturer = vehicle.Manufacturer;
            vehicleDTO.Model = vehicle.Model;
            vehicleDTO.Type = vehicle.Type;
            vehicleDTO.EngineHorsepower = vehicle.EngineHorsepower;
            vehicleDTO.EngineDisplacement = vehicle.EngineDisplacement;
            vehicleDTO.DriverId = vehicle.DriverId;

            return vehicleDTO;
        }
    }
}
