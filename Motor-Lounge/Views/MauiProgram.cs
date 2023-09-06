using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Motor_Lounge.Data;
using Motor_Lounge.Services;
using Motor_Lounge.ViewModels;
using System.Reflection;
using CommunityToolkit.Maui;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Entities.Helpers;
using System.Security.Cryptography;
using System.Text;
using Motor_Lounge.Entities.Users;
using SkiaSharp.Views.Maui.Controls.Hosting;

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
            .UseSkiaSharp()
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
        builder.Services.AddSingleton<IInformationService, InformationService>();
        builder.Services.AddSingleton<IApplicationService, ApplicationService>();

        //Registering ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddSingleton<FilterViewModel>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();
        builder.Services.AddTransient<RegistrationViewModel>();
        builder.Services.AddSingleton<CarViewModel>();
        builder.Services.AddSingleton<CarDetailsViewModel>();
        builder.Services.AddSingleton<AddViewModel>();
        builder.Services.AddSingleton<ApplicationsViewModel>();

        //Registering Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegistrationPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<CarPage>();
        builder.Services.AddTransient<CarDetailsPage>();
        builder.Services.AddSingleton<FilterPage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<AdminCarDetailsPage>();
        builder.Services.AddTransient<AdminAddPage>();
        builder.Services.AddTransient<AdminApplicationsPage>();

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

        var unitOfWork = provider.GetService<IUnitOfWork>();
        await unitOfWork.RemoveDatbaseAsync();
        await unitOfWork.CreateDatabaseAsync();
        var reg = provider.GetService<RegistrationViewModel>();

        var salt = RandomNumberGenerator.GetBytes(32);
        await unitOfWork.userRepository.AddAsync(new User("root", "root", reg.GenerateSaltedHash(Encoding.UTF8.GetBytes("root"), salt), salt, true));
        await unitOfWork.SaveAllAsync();

        IList<Car> cars = new List<Car>() {
               new Car(
    new Specification(2022, "Toyota", "Corolla"),
    new Equipment("Premium Sound System", "Leather Seats"),
    new Photo(new List<string>{"id4.jpg", "id4.jpg"}),
    new Price{ IndividualPrice = 20000, CorporationPrice = 19000 },
    new Appearance("Red", "Black", "Red", "Leather"),
    new Characteristics("Gasoline", 2.0m, 0, "Automatic", "FWD", "Sedan", 4),
    new Information("This car is in excellent condition, with low mileage and one previous owner.")),

                new Car(
    new Specification(2023, "BMW", "X5"),
    new Equipment("Navigation System", "Heated Seats"),
    new Photo(new List<string>{ "id4.jpg", "id4.jpg"}),
    new Price{ IndividualPrice = 65000, CorporationPrice = 63000 },
    new Appearance("Black", "Beige", "Black", "Leather"),
    new Characteristics("Diesel", 3.0m, 15000, "Automatic", "AWD", "SUV", 5),
    new Information("This luxury SUV has all the features you need for a comfortable and enjoyable ride.")),

                new Car(
    new Specification(2020, "Honda", "Accord"),
    new Equipment("Sunroof", "Blind Spot Monitor"),
    new Photo(new List<string>{"id4.jpg", "id4.jpg" }),
    new Price{ IndividualPrice = 30000, CorporationPrice = 28000 },
    new Appearance("Silver", "Black", "Silver", "Cloth"),
    new Characteristics("Gasoline", 1.5m, 20000, "CVT", "FWD", "Sedan", 4),
    new Information("This car has been well-maintained and is in excellent condition.")),

                new Car(
    new Specification(2021, "Ford", "F-150"),
    new Equipment("Towing Package", "Apple CarPlay"),
    new Photo(new List<string>{"id4.jpg", "id4.jpg" }),
    new Price{ IndividualPrice = 45000, CorporationPrice = 42000 },
    new Appearance("Blue", "Gray", "Blue", "Leather"),
    new Characteristics("Gasoline", 3.5m, 10000, "Automatic", "AWD", "Truck", 4),
    new Information("This pickup truck is perfect for work or play.")),

                new Car(
    new Specification(2019, "Jeep", "Cherokee"),
    new Equipment("Remote Start", "Android Auto"),
    new Photo(new List<string>{"id4.jpg", "id4.jpg" }),
    new Price{ IndividualPrice = 28000, CorporationPrice = 26000 },
    new Appearance("White", "Black", "White", "Leather"),
    new Characteristics("Gasoline", 2.4m, 30000, "Automatic", "FWD", "SUV", 4),
    new Information("This SUV is in great condition."))};

        /*                 new Car(new Specification(2021, "BMW", "X5"),
            new Equipment("Navigation system", "GPS, Bluetooth"),
            new Photo(new List<string> { "id4.jpg", "id4.jpg" }),
            new Price { IndividualPrice = 55000, CorporationPrice = 50000 },
            new Appearance("Red", "Black", "Silver", "Leather"),
            new Characteristics("Gasoline", 3.0M, 25000, "Automatic", "AWD", "SUV", 5),
            new Information ("One owner, accident-free" )),

                          new Car(new Specification(2022, "Audi", "A4"),
            new Equipment("Premium Plus package", "Bang & Olufsen audio system, Virtual Cockpit"),
            new Photo(new List<string> { "id4.jpg", "id4.jpg" }),
            new Price { IndividualPrice = 45000, CorporationPrice = 42000 },
            new Appearance("Black", "Beige", "Black", "Leather"),
            new Characteristics("Gasoline", 2.0M, 15000, "Automatic", "FWD", "Sedan", 4),
            new Information ("Clean title, low mileage" )),

                            new Car(new Specification(2020, "Toyota", "RAV4"),
            new Equipment("Adventure package", "All-weather floor mats, Roof rack"),
            new Photo(new List<string> { "id4.jpg", "id4.jpg" }),
            new Price { IndividualPrice = 32000, CorporationPrice = 30000 },
            new Appearance("White", "Black", "Silver", "Fabric"),
            new Characteristics("Gasoline", 2.5M, 20000, "Automatic", "AWD", "SUV", 5),
            new Information ("Well-maintained, non-smoker" )),

                            new Car(new Specification(2018, "Honda", "Civic"),
            new Equipment("Touring package", "Lane departure warning, Adaptive cruise control"),
            new Photo(new List<string> { "id4.jpg", "id4.jpg" }),
            new Price { IndividualPrice = 18000, CorporationPrice = 16000 },
            new Appearance("Gray", "Black", "Gray", "Leather"),
            new Characteristics("Gasoline", 1.5M, 50000, "Automatic", "FWD", "Sedan", 4),
            new Information ("Excellent condition, clean title" )),

                            new Car(new Specification(2017, "Nissan", "Altima"),
            new Equipment("SR package", "Sport-tuned suspension, Leather-wrapped steering wheel"),
            new Photo(new List<string> { "id4.jpg", "id4.jpg" }),
            new Price { IndividualPrice = 12000, CorporationPrice = 10000 },
            new Appearance("Gray", "Black", "Gray", "Leather"),
            new Characteristics("Gasoline", 1.5M, 50000, "Automatic", "FWD", "Sedan", 4),
            new Information ("Excellent condition, clean title" )),

                            new Car(
            new Specification(2022, "Ford", "Mustang"),
            new Equipment("Heated Seats", "Remote Start"),
            new Photo(new List<string>{"id4.jpg", "id4.jpg" }),
            new Price{ IndividualPrice = 30000, CorporationPrice = 28000 },
            new Appearance("Black", "White", "Black", "Leather"),
            new Characteristics("Gasoline", 3.0m, 0, "Automatic", "RWD", "Coupe", 2),
            new Information("This car is in like-new condition, with very low mileage and a clean Carfax report.")),                  

                            new Car(
            new Specification(2023, "Tesla", "Model S"),
            new Equipment("Autopilot", "All-Wheel Drive"),
            new Photo(new List<string>{"id4.jpg", "id4.jpg" }),
            new Price{ IndividualPrice = 80000, CorporationPrice = 78000 },
            new Appearance("White", "Black", "White", "Leather"),
            new Characteristics("Electric", 0, 1000, "Automatic", "AWD", "Sedan", 4),
            new Information("This car is fully loaded with all available options and has never been in an accident.")),

                            new Car(
            new Specification(2020, "Honda", "Accord"),
            new Equipment("Sunroof", "Heated Mirrors"),
            new Photo(new List<string>{"id4.jpg", "id4.jpg" }),
            new Price{ IndividualPrice = 22000, CorporationPrice = 21000 },
            new Appearance("Gray", "Black", "Gray", "Leather"),
            new Characteristics("Gasoline", 2.0m, 0, "Automatic", "FWD", "Sedan", 5),
            new Information("This car has only had one owner and comes with a complete service history.")),

                            new Car(
            new Specification(2022, "BMW", "X5"),
            new Equipment("Navigation System", "Panoramic Sunroof"),
            new Photo(new List<string>{"id4.jpg", "id4.jpg" }),
            new Price{ IndividualPrice = 60000, CorporationPrice = 58000 },
            new Appearance("Blue", "Black", "Blue", "Leather"),
            new Characteristics("Gasoline", 3.0m, 0, "Manual", "AWD", "SUV", 5),
            new Information("This car is in excellent condition, with low mileage and a clean Carfax report."))};*/

        foreach (var car in cars)
        {
            await unitOfWork.carRepository.AddAsync(car);
        }
        await unitOfWork.SaveAllAsync();


        IList<Information> news = new List<Information>()
        {
            new Information("id4.jpg"),
            new Information("id4.jpg"),
            new Information("id4.jpg"),
        };

        foreach (var news_ in news)
        {
            await unitOfWork.newsRepository.AddAsync(news_);
        }
        await unitOfWork.SaveAllAsync();
    }
}
