﻿using Motor_Lounge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Entities.Users
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        //credentials
        public byte[] HashedPassword { get; set; }
        public byte[] Salt { get; set; }

        public bool IsAdmin { get; set; }

        public User(string userName, string email, byte[] hashedPassword, byte[] salt, bool isAdmin = false)
        {
            UserName = userName;
            Email = email;
            HashedPassword = hashedPassword;
            Salt = salt;
            IsAdmin = isAdmin;
        }

        public User() { }
    }
}
