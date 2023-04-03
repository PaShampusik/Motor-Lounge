using Motor_Lounge.Models.Helpers;
using Motor_Lounge.Models.Owners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Models.Cars
{
    internal class Car
    {
        public List<Equipment> equipment;
        public Photo photos;
        public Price price;
        public Appearance appearance;
        public Characteristics characteristics;
        public Information information;
        public List<Owner> owners;
    }
}
