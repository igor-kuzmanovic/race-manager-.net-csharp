using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Server
{
    class VehicleManager
    {
        public static VehicleManager Instance { get; } = new VehicleManager();

        static VehicleManager() { }

        private VehicleManager() { }

        public User GetVehicle(Expression<Func<User, bool>> predicate)
        {
            using (var context = new Context())
            {
                return context.Vehicles.FirstOrDefault(predicate);
            }
        }

        public IEnumerable<User> GetVehicles(Expression<Func<User, bool>> predicate)
        {
            using (var context = new Context())
            {
                return context.Vehicles.Where(predicate).ToList();
            }
        }

        public int InsertVehicle(User vehicle)
        {
            using (var context = new Context())
            {
                context.Vehicles.Add(vehicle);
                context.SaveChanges();
                return vehicle.Id;
            }
        }

        public bool UpdateVehicle(User vehicle)
        {
            using (var context = new Context())
            {
                var oldVehicle = GetVehicle(v => v.Id == vehicle.Id);

                if (oldVehicle == null)
                    return false;

                oldVehicle.Manufacturer = vehicle.Manufacturer;
                oldVehicle.Model = vehicle.Model;
                oldVehicle.Type = vehicle.Type;
                oldVehicle.EngineHorsepower = vehicle.EngineHorsepower;
                oldVehicle.EngineDisplacement = vehicle.EngineDisplacement;
                oldVehicle.DriverId = vehicle.DriverId;
                oldVehicle.Driver = vehicle.Driver;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteVehicle(int id)
        {
            using (var context = new Context())
            {
                var vehicle = GetVehicle(v => v.Id == id);

                if (vehicle == null)
                    return false;

                context.Vehicles.Remove(vehicle);
                context.SaveChanges();
                return true;
            }
        }
    }
}
