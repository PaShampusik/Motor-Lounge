using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class RegistrationPage : ContentPage
{
    private RegistrationViewModel _registrationViewModel;
	public RegistrationPage(RegistrationViewModel registrationViewModel)
	{
        InitializeComponent();
        _registrationViewModel = registrationViewModel;
        BindingContext = _registrationViewModel;
    }
}