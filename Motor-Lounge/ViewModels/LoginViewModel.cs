using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Services.MongoDB;
using Motor_Lounge.Services.Navigation;
using Motor_Lounge.ViewModels.Base;
using System.Diagnostics;
using System.Windows.Input;

namespace Motor_Lounge.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string _name;

        [ObservableProperty]
        public string _email;

        [ObservableProperty]
        public string _password;

        [RelayCommand]
        public async void Login()
        {

        }
    }
}
j