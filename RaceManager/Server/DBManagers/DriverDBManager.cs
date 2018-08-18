namespace Server
{
    class DriverDBManager : BaseDBManager<Driver>
    {
        public static DriverDBManager Instance { get; } = new DriverDBManager();

        static DriverDBManager() { }

        private DriverDBManager() { }      

        public override bool Update(Driver driver)
        {
            using (var context = new DBContext())
            {
                var oldDriver = Get(d => d.Id == driver.Id);

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
    }
}
