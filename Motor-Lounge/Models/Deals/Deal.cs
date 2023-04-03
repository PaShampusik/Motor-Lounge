using Microsoft.VisualBasic;
using Motor_Lounge.Models.Cars;
using Motor_Lounge.Models.Helpers;
using Motor_Lounge.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Information = Motor_Lounge.Models.Helpers.Information;

namespace Motor_Lounge.Models.Deals
{
    internal class Deal
    {
        public Specification Specification { get; set; }
        public User User { get; set; }
        public Information Information { get; set; }
        public int LoanTerms { get; set; }
        public Price Price { get; set; }
        public DateTime Date { get; set; }
    }
}
