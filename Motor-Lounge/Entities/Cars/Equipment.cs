using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Models.Cars
{
    public class Equipment
    {
        public string NameOfFeatures;
        public string Features;

        public Equipment(string nameOfFeatures, string features) 
        {
            NameOfFeatures = nameOfFeatures;
            Features = features;           
        }

        public Equipment() { }
    }
}
