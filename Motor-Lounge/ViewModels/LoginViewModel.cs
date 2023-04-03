using Motor_Lounge.Services.Navigation;
using Motor_Lounge.ViewModels.Base;

namespace Motor_Lounge.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
