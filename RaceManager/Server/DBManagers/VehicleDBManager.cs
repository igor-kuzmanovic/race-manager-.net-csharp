namespace Server
{
    class VehicleDBManager : BaseDBManager<Vehicle>
    {
        public static VehicleDBManager Instance { get; } = new VehicleDBManager();

        static VehicleDBManager() { }

        private VehicleDBManager() { }

        public override bool Update(Vehicle vehicle)
        {
            using (var context = new DBContext())
            {
                var oldVehicle = Find(v => v.Id == vehicle.Id);

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
    }
}
