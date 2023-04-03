using Motor_Lounge.Services.Navigation;
using Motor_Lounge.ViewModels.Base;

namespace Motor_Lounge.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
