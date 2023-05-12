using Motor_Lounge.Entities;
using Motor_Lounge.Models.Helpers;

namespace Motor_Lounge.Models.Cars
{
    public class Car : Entity
    {
        public Equipment Equipment;
        public Photo Photos;
        public Price Price;
        public Specification Specification;
        public Appearance Appearance;
        public Characteristics Characteristics;
        public Information Information;

        public Car(Specification specification, Equipment equipment, Photo photos, Price price, Appearance appearance, Characteristics characteristics, Information information)
        {
            Specification = specification;
            Equipment = equipment;
            Photos = photos;
            Price = price;
            Appearance = appearance;
            Characteristics = characteristics;
            Information = information;
        }
        
        public Car() { }
    }
}
