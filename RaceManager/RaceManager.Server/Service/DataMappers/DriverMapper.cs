using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.Service.Core.DataMappers;
using RaceManager.Server.Service.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.Service.DataMappers
{
    class DriverMapper : DataMapper<DriverDAO, DriverDTO>, IDriverMapper
    {
        public static DriverMapper Instance { get; } = new DriverMapper();

        static DriverMapper() { }

        private DriverMapper() { }

        public override DriverDAO Map(DriverDTO driverDTO)
        {
            var driver = new DriverDAO();

            if (driverDTO != null)
            {
                driver.Id = driverDTO.Id;
                driver.FirstName = driverDTO.FirstName;
                driver.LastName = driverDTO.LastName;
                driver.UMCN = driverDTO.UMCN;
            }

            return driver;
        }

        public override DriverDTO Map(DriverDAO driver)
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