using CommunityToolkit.Mvvm.ComponentModel;

namespace Motor_Lounge.ViewModels.Base
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool isBusy;
        [ObservableProperty]
        public string title;
    }
}
