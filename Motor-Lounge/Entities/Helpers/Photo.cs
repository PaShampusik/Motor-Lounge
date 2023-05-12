using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Models.Helpers
{
    public class Photo
    {
        public List<string> Photos { get; set; }

        public Photo(List<string> photos)
        {
            Photos = photos;
        }

        public Photo() { }
    }
}
