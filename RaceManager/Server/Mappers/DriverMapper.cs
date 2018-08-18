using Service;
using System.Linq;

namespace Server
{
    class DriverMapper : BaseMapper<Driver, DriverDTO>
    {
        public static DriverMapper Instance { get; } = new DriverMapper();

        static DriverMapper() { }

        private DriverMapper() { }

        public override Driver Map(DriverDTO driverDTO)
        {
            var driver = new Driver();

            driver.Id = driverDTO.Id;
            driver.FirstName = driverDTO.FirstName;
            driver.LastName = driverDTO.LastName;
            driver.UMCN = driverDTO.UMCN;
            driver.Vehicles = driverDTO.VehicleIds.Select(v => new Vehicle() { Id = v }).ToList();
            driver.Races = driverDTO.RaceIds.Select(r => new Race() { Id = r }).ToList();

            return driver;
        }

        public override DriverDTO Map(Driver driver)
        {
            var driverDTO = new DriverDTO();

            driverDTO.Id = driver.Id;
            driverDTO.FirstName = driver.FirstName;
            driverDTO.LastName = driver.LastName;
            driverDTO.UMCN = driver.UMCN;
            driverDTO.VehicleIds = driver.Vehicles.Select(v => v.Id).ToList();
            driverDTO.RaceIds = driver.Races.Select(r => r.Id).ToList();

            return driverDTO;
        }
    }
}
