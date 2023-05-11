using Motor_Lounge.Models.Users;
using Motor_Lounge.Services;
using Motor_Lounge.ViewModels.Base;
using System.ComponentModel;

namespace Motor_Lounge.ViewModels
{
    internal class RegistrationViewModel : BaseViewModel
    {
        public readonly IUserService _userService;
        public string email;
        public string password;
        public string confirmPassword;
        public bool registrationSuccessful;
    }
}
