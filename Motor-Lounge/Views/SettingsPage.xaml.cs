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

    public event EventHandler<ToggledEventArgs>? Toggled = null;

    public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(SettingsPage), false, BindingMode.TwoWay);

    public bool IsToggled
    {
        get => (bool)GetValue(IsToggledProperty);
        set => SetValue(IsToggledProperty, value);
    }

    public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(SettingsPage));

    public ICommand ToggledCommand
    {
        get => (ICommand)GetValue(ToggledCommandProperty);
        set => SetValue(ToggledCommandProperty, value);
    }

    void CustomSwitch_SwitchPanUpdate(CustomSwitch customSwitch, SwitchPanUpdatedEventArgs e)
    {
        Color fromBackgroundColor = e.IsToggled ? Color.FromArgb("#001f48") : Colors.White;
        Color toBackgroundColor = e.IsToggled ? Colors.White : Color.FromArgb("#001f48");

        Color fromBorderColor = e.IsToggled ? Color.FromArgb("#16447a") : Color.FromArgb("#f1ca1b");
        Color toBorderColor = e.IsToggled ? Color.FromArgb("#f1ca1b") : Color.FromArgb("#16447a");

        double t = e.Percentage * 0.01;

        KnobContent.TranslationX = -(e.TranslateX + e.XRef);

        customSwitch.BackgroundColor = ColorAnimationUtil.ColorAnimation(fromBackgroundColor, toBackgroundColor, t);
        customSwitch.Stroke = ColorAnimationUtil.ColorAnimation(fromBorderColor, toBorderColor, t);
    }

    void CustomSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Toggled?.Invoke(sender, e);
    }
}
