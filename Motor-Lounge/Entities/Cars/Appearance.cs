using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Entities.Cars
{
    public class Appearance
    {
        public string Color {  get; set; }//
        public string InteriorColor { get; set; }//
        public string CarColor { get; set; }//
        public string InteriorMaterial { get; set; }//

        public Appearance(string color, string interiorColor, string carColor, string InteriorMaterail)
        {
            Color = color;
            InteriorColor = interiorColor;
            CarColor = carColor;
            InteriorMaterial = InteriorMaterail;
        }

        public Appearance() { }

        public override string ToString()
        {
            return Color + " " + InteriorColor + " " + CarColor + " " + InteriorMaterial;
        }
    }
}
