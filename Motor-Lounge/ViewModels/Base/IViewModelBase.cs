using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Services;

namespace Motor_Lounge.ViewModels.Base;

public interface IViewModelBase : IQueryAttributable
{
    //public INavigationService NavigationService { get; }

    public IAsyncRelayCommand InitializeAsyncCommand { get; }

    public bool IsBusy { get; }

    public bool IsInitialized { get; }

    Task InitializeAsync();
}