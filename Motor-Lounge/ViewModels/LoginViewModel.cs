using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Services;
using Motor_Lounge.ViewModels.Base;
using System.Diagnostics;
using System.Windows.Input;

namespace Motor_Lounge.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {

        public readonly IUserService _userService;

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;

        [RelayCommand]
        public async void Login()
        {

        }

        [RelayCommand] 
        public async Task GoToRegistration()
        {
            await Shell.Current.GoToAsync($"RegistrationPage");
        }
    }
}
