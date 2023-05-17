using System.Windows.Input;
using IeuanWalker.Maui.Switch;
using IeuanWalker.Maui.Switch.Events;
using IeuanWalker.Maui.Switch.Helpers;
using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class SettingsPage : ContentPage
{

    private MainViewModel viewModel;
    private SettingsViewModel viewModelSettings;
    public SettingsPage(MainViewModel _viewModel, SettingsViewModel _settingsViewModel)
    {
        InitializeComponent();
        viewModel = _viewModel;
        viewModelSettings = _settingsViewModel;
        BindingContext = viewModelSettings;
    }

}
