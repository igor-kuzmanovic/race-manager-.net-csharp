using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Server.Managers
{
    class DriverManager
    {
        public static DriverManager Instance { get; } = new DriverManager();

        static DriverManager() { }

        private DriverManager() { }

        public Driver GetDriver(Expression<Func<Driver, bool>> predicate)
        {
            using (var context = new Context())
            {
                return context.Drivers.FirstOrDefault(predicate);
            }
        }

        public IEnumerable<Driver> GetDrivers(Expression<Func<Driver, bool>> predicate)
        {
            using (var context = new Context())
            {
                return context.Drivers.Where(predicate).ToList();
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
                var oldDriver = GetDriver(d => d.Id == driver.Id);

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
                var driver = GetDriver(d => d.Id == id);

                if (driver == null)
                    return false;

                context.Drivers.Remove(driver);
                context.SaveChanges();
                return true;
            }
        }
    }
}
