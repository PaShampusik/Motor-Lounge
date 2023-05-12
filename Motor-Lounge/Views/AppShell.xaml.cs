using Motor_Lounge.Views;

namespace Motor_Lounge;

public partial class AppShell : Shell
{
	public AppShell()
	{
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(FilterPage), typeof(FilterPage));
		Routing.RegisterRoute(nameof(CarDetailsPage), typeof(CarDetailsPage));
		Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
		Routing.RegisterRoute(nameof(CarPage), typeof(CarPage));
		InitializeComponent();
	}
}
