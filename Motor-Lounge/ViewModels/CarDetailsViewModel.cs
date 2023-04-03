using Motor_Lounge.Services.Navigation;
using Motor_Lounge.ViewModels.Base;

namespace Motor_Lounge.ViewModels
{
    public class CarDetailsViewModel : ViewModelBase
    {
        public CarDetailsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
