using RaceManagerServer.DataAccess.Core.Domain;
using RaceManagerServer.Service.Core.Converters;
using RaceManagerServer.Service.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManagerServer.Service.Converters
{
    class DriverConverter : Converter<Driver, DriverDTO>, IDriverConverter
    {
        public static DriverConverter Instance { get; } = new DriverConverter();

        static DriverConverter() { }

        private DriverConverter() { }

        public override Driver Convert(DriverDTO driverDTO)
        {
            var driver = new Driver();

            driver.Id = driverDTO.Id;
            driver.FirstName = driverDTO.FirstName;
            driver.LastName = driverDTO.LastName;
            driver.UMCN = driverDTO.UMCN;

            return driver;
        }

        public override DriverDTO Convert(Driver driver)
        {
            var driverDTO = new DriverDTO();

            driverDTO.Id = driver.Id;
            driverDTO.FirstName = driver.FirstName;
            driverDTO.LastName = driver.LastName;
            driverDTO.UMCN = driver.UMCN;

            return driverDTO;
        }
    }
}