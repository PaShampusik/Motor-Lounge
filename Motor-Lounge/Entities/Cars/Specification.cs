using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Models.Cars
{
    public class Specification
    {
        public int Year;
        public string Brand;
        public string Model;

        public Specification(int year, string brand, string model)
        {
            Year = year;
            Brand = brand;
            Model = model;
        }

        public Specification() { }
    }
}
