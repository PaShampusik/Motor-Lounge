using Motor_Lounge.Services.Navigation;
using Motor_Lounge.ViewModels.Base;

namespace Motor_Lounge.ViewModels
{
    internal class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
