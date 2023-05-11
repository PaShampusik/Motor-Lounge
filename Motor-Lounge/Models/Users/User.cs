using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Models.Users
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Credentials Credentials { get; set; }
    }
}
