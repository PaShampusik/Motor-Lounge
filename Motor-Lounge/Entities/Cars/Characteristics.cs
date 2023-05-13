namespace Motor_Lounge.Entities.Cars
{
    public class Characteristics
    {
        public string EngineType { get; set; }//
        public decimal EngineVolume { get; set; }//
        public long Milleage { get; set; }//
        public string GearboxType { get; set; }//
        public string DriveType { get; set; }//
        public string BodyType { get; set; }//
        public int NumOfDoors { get; set; }//

        public Characteristics(string engineType, decimal engineVolume, long milleage, string gearboxType, string driveType, string bodyType, int numOfDoors)
        {
            EngineType = engineType;
            EngineVolume = engineVolume;
            Milleage = milleage;
            GearboxType = gearboxType;
            DriveType = driveType;
            BodyType = bodyType;
            NumOfDoors = numOfDoors;
        }

        public Characteristics() { }
    }
}
