using Microsoft.Extensions.Logging;
using Motor_Lounge.Services;
using Motor_Lounge.Services.Settings;
using Motor_Lounge.Services.Navigation;
using Motor_Lounge.Services.Identity;
using Motor_Lounge.ViewModels;
using Motor_Lounge.Services.MongoDB;

namespace Motor_Lounge.Views;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        //Registering Services
        builder.Services.AddSingleton<ISettingsService, SettingsService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<IIdentityService, IdentityService>();
        builder.Services.AddSingleton<IMongoDBService, MongoDBService>();

        //Registering ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<CarDetailsViewModel>();
        builder.Services.AddTransient<NewFilterViewModel>();
        builder.Services.AddTransient<MileageFilterViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<RegistrationViewModel>();

        //Registering Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<CarDetailsPage>();
        builder.Services.AddTransient<MileageFilterPage>();
        builder.Services.AddTransient<NewFilterPage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<RegistrationPage>();

        return builder.Build();
    }
}
