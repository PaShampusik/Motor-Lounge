using Motor_Lounge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Models.Users
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        //credentials
        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        public User(string userName, string email, string hashedPassword, string salt)
        {
            UserName = userName;
            Email = email;
            HashedPassword = hashedPassword;
            Salt = salt;
        }
    }
}
