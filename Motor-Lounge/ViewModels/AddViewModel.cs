using CommunityToolkit.Mvvm.ComponentModel;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Entities.Helpers;
using Motor_Lounge.Services;

namespace Motor_Lounge.ViewModels
{
    public partial class AddViewModel : ObservableObject
    {
        [ObservableProperty]
        public Specification specification = new(2020, "BMW", "M5");

        [ObservableProperty]
        public Equipment equipment = new("Wifi", "Oil");

        [ObservableProperty]
        public Photo photo = new(new List<string>() { "id4.jpg", "id4.jpg"});

        [ObservableProperty]
        public Price price = new(18000, 20000);

        [ObservableProperty]
        public Appearance appearance = new("Black", "White", "Black", "Shit");

        [ObservableProperty]
        public Characteristics characteristics = new("Diesel", 2, 120000, "Manual", "AWD", "Sedan", 5);

        [ObservableProperty]
        public Information information = new("Good car, but needs a lot of oil :(");

        private ICarService carService;

        public AddViewModel(ICarService _carService)
        {          
            carService = _carService;
        }

        public async Task Save()
        {
            await carService.AddAsync(new Car(Specification, Equipment, Photo, Price, Appearance, Characteristics, Information));            
        }
    }
}
