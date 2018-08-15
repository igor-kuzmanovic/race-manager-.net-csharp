using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Managers
{
    class DriverManager
    {
        public static DriverManager Instance { get; } = new DriverManager();

        static DriverManager() { }

        private DriverManager() { }

        public Driver GetDriverById(int id)
        {
            using (var context = new Context())
            {
                return context.Drivers.FirstOrDefault(d => d.Id == id);
            }
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            using (var context = new Context())
            {
                return context.Drivers.ToList();
            }
        }

        public int InsertDriver(Driver driver)
        {
            using (var context = new Context())
            {
                context.Drivers.Add(driver);
                context.SaveChanges();
                return driver.Id;
            }
        }

        public bool UpdateDriver(Driver driver)
        {
            using (var context = new Context())
            {
                var oldDriver = GetDriverById(driver.Id);

                if (oldDriver == null)
                    return false;

                oldDriver.FirstName = driver.FirstName;
                oldDriver.LastName = driver.LastName;
                oldDriver.UMCN = driver.UMCN;
                oldDriver.Vehicles = oldDriver.Vehicles;
                oldDriver.Races = oldDriver.Races;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteDriver(int id)
        {
            using (var context = new Context())
            {
                var driver = GetDriverById(id);

                if (driver == null)
                    return false;

                context.Drivers.Remove(driver);
                context.SaveChanges();
                return true;
            }
        }
    }
}
