using Microsoft.VisualBasic;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Entities.Helpers;
using Motor_Lounge.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Information = Motor_Lounge.Entities.Helpers.Information;

namespace Motor_Lounge.Entities.Deals
{
    public class Deal
    {
        public Specification Specification { get; set; }
        public User User { get; set; }
        public Information Information { get; set; }
        public int LoanTerms { get; set; }
        public Price Price { get; set; }
        public DateTime Date { get; set; }
    }
}
