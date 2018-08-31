using RaceManager.Client.Core.DataMappers;
using RaceManager.Client.DriverService;
using RaceManager.Client.Models;
using System;
using System.Collections.ObjectModel;

namespace RaceManager.Client.DataMappers
{
    class DriverMapper : DataMapper<Driver, DriverDTO>, IDriverMapper
    {
        public static DriverMapper Instance { get; } = new DriverMapper();

        static DriverMapper() { }

        private DriverMapper() { }

        public override Driver Map(DriverDTO driverDTO)
        {
            var driver = new Driver();

            if (driverDTO != null)
            {
                driver.Id = driverDTO.Id;
                driver.FirstName = driverDTO.FirstName;
                driver.LastName = driverDTO.LastName;
                driver.UMCN = driverDTO.UMCN;
            }

            return driver;
        }

        public override DriverDTO Map(Driver driver)
        {
            var driverDTO = new DriverDTO();

            if (driver != null)
            {
                driverDTO.Id = driver.Id;
                driverDTO.FirstName = driver.FirstName;
                driverDTO.LastName = driver.LastName;
                driverDTO.UMCN = driver.UMCN;
            }

            return driverDTO;
        }
    }
}