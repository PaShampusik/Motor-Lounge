using Motor_Lounge.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Models.Users
{
    public class Salesman : Consultant
    {
        public int SoldCount { get; set; }
    }
}
