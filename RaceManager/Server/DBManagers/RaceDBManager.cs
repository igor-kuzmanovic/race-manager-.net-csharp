namespace Server
{
    class RaceDBManager : BaseDBManager<Race>
    {
        public static RaceDBManager Instance { get; } = new RaceDBManager();

        static RaceDBManager() { }

        private RaceDBManager() { }      

        public override bool Update(Race race)
        {
            using (var context = new DBContext())
            {
                var oldRace = Get(r => r.Id == race.Id);

                if (oldRace == null)
                    return false;

                oldRace.EventDate = race.EventDate;
                oldRace.EventLocation = race.EventLocation;
                oldRace.Drivers = race.Drivers;
                context.SaveChanges();
                return true;
            }
        }
    }
}
