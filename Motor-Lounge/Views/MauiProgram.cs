using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Motor_Lounge.Data;
using Motor_Lounge.Services;
using Motor_Lounge.ViewModels;
using System.Reflection;
using CommunityToolkit.Maui;
using Motor_Lounge.Models.Cars;
using Motor_Lounge.Models.Helpers;

namespace Motor_Lounge.Views;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "Motor_Lounge.Views.appsettings.json";

        var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseMauiCommunityToolkit();

#if DEBUG
        builder.Logging.AddDebug();

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);
        builder.Configuration.AddJsonStream(stream);
#endif
        //Registering Services
        builder.Services.AddSingleton<ICarService, CarService>();
        builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

        //Registering ViewModels
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();
        builder.Services.AddSingleton<RegistrationViewModel>();

        //Registering Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegistrationPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<FilterPage>();
        builder.Services.AddTransient<CarDetailsPage>();
        builder.Services.AddTransient<SettingsPage>();

        AddDbContext(builder);
        SeedData(builder);

        return builder.Build();
    }
    private static void AddDbContext(MauiAppBuilder builder)
    {
        var connectionString = builder.Configuration
        .GetConnectionString("SqliteConnection");
        string dataDirectory = string.Empty;
#if ANDROID
            dataDirectory = FileSystem.AppDataDirectory + Path.DirectorySeparatorChar;
#else
        dataDirectory = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar;
#endif
        connectionString = string.Format(connectionString, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlite(connectionString)
        .EnableSensitiveDataLogging()
        .Options;
        builder.Services.AddSingleton((s) => new AppDbContext(options));
    }

    public async static void SeedData(MauiAppBuilder builder)
    {
        using var provider = builder.Services.BuildServiceProvider();
        try
        {
            var unitOfWork = provider.GetService<IUnitOfWork>();
            await unitOfWork.RemoveDatbaseAsync();
            await unitOfWork.CreateDatabaseAsync();
            IList<Car> cars = new List<Car>() {
                new Car(new Specification(), new Equipment(), new Photo(), new Price(), new Appearance(), new Characteristics(), new Information()) ,
                new Car(new Specification(), new Equipment(), new Photo(), new Price(), new Appearance(), new Characteristics(), new Information())
            };

            foreach (var car in cars)
            {
                await unitOfWork.carRepository.AddAsync(car);
            }
            await unitOfWork.SaveAllAsync();
        }
        catch (Exception ex)
        {
        }

        // Add sets
    }
}
