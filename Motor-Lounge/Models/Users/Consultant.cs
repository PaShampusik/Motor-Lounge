using Microsoft.VisualBasic;
using Motor_Lounge.Models.Helpers;

namespace Motor_Lounge.Models.Users
{
    public class Consultant : User
    {
        public Helpers.Information Information { get; set; }
        public string Type { get; set; }
        public Photo photos { get; set; }
    }
}
