using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Entities.Helpers
{
    public class Information : Entity
    {
        public string Info { get; set; }

        public Information(string info)
        {
            Info = info;
        }

        public Information()
        { }
    }
}
