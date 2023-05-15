using Motor_Lounge.Views;

namespace Motor_Lounge;

public partial class AppShell : Shell
{
	public AppShell()
	{
		//user pages
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(FilterPage), typeof(FilterPage));
		Routing.RegisterRoute(nameof(CarDetailsPage), typeof(CarDetailsPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
		Routing.RegisterRoute(nameof(CarPage), typeof(CarPage));

		//superuser pages
        Routing.RegisterRoute(nameof(AdminCarDetailsPage), typeof(AdminCarDetailsPage));
        Routing.RegisterRoute(nameof(AdminAddPage), typeof(AdminAddPage));
        Routing.RegisterRoute(nameof(AdminApplicationsPage), typeof(AdminApplicationsPage));

        InitializeComponent();
	}
    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);

        if (args.Source == ShellNavigationSource.ShellSectionChanged)
        {
            var navigation = Shell.Current.Navigation;
            var pages = navigation.NavigationStack;
            for (var i = pages.Count - 1; i >= 1; i--)
            {
                navigation.RemovePage(pages[i]);
            }
        }
    }
}
