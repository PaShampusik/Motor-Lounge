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
        public List<string> Features;

        public Equipment(string nameOfFeatures, List<string> features) 
        {
            NameOfFeatures = nameOfFeatures;
            Features = features;           
        }
    }
}
