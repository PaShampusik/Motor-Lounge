using Motor_Lounge.Entities;
using Motor_Lounge.Models.Helpers;

namespace Motor_Lounge.Models.Cars
{
    public class Car : Entity
    {
        public List<Equipment> Equipment;
        public Photo Photos;
        public Price Price;
        public Appearance Appearance;
        public Characteristics Characteristics;
        public Information Information;

        public Car(List<Equipment> equipment, Photo photos, Price price, Appearance appearance, Characteristics characteristics, Information information)
        {
            Equipment = equipment;
            Photos = photos;
            Price = price;
            Appearance = appearance;
            Characteristics = characteristics;
            Information = information;
        }   
    }
}
