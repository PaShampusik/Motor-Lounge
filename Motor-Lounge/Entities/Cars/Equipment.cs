using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Entities.Cars
{
    public class Equipment
    {
        public string NameOfFeatures { get; set; }//
        public string Features { get; set; }//

        public Equipment(string nameOfFeatures, string features) 
        {
            NameOfFeatures = nameOfFeatures;
            Features = features;           
        }

        public Equipment() { }
    }
}
