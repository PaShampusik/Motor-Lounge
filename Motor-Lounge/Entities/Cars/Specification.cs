using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Entities.Cars
{
    public class Specification
    {
        public int Year { get; set; }//
        public string Brand { get; set; }//
        public string Model { get; set; }//

        public Specification(int year, string brand, string model)
        {
            Year = year;
            Brand = brand;
            Model = model;
        }

        public Specification() { }
    }
}
