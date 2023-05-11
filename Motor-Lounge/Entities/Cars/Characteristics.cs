namespace Motor_Lounge.Models.Cars
{
    public class Characteristics
    {
        public string EngineType;
        public decimal EngineVolume;
        public long Milleage;
        public string GearboxType;
        public string DriveType;
        public string BodyType;
        public int NumOfDoors;

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
    }
}
