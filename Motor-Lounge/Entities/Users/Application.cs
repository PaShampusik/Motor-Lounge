using Motor_Lounge.Entities.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Entities.Users
{
    public class Application : Entity
    {
        public string UserEmail { get; set; }

        public int CarId { get; set; }

        public Application()
        {
        }

        public Application(string user, int car)
        {
            UserEmail = user;
            CarId = car;
        }
    }
}
