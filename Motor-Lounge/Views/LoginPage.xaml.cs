using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class LoginPage : ContentPage
{
	private LoginViewModel _loginViewModel;


	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		_loginViewModel = loginViewModel;
		BindingContext = _loginViewModel;
	}
}