namespace Server
{
    class Vehicle : BaseEntity
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public double EngineHorsepower { get; set; }
        public double EngineDisplacement { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
