using Motor_Lounge.Entities;
using Motor_Lounge.Entities.Helpers;

namespace Motor_Lounge.Entities.Cars
{
    public class Car : Entity
    {
        public Equipment Equipment { get; set; }
        public Photo Photos { get; set; }//
        public Price Price { get; set; }//
        public Specification Specification { get; set; }
        public Appearance Appearance { get; set; }
        public Characteristics Characteristics { get; set; }
        public Information Information { get; set; }

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
