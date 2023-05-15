using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Entities.Helpers;
using Motor_Lounge.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Motor_Lounge.ViewModels
{
    public partial class AddViewModel : ObservableObject
    {
        [ObservableProperty]
        public Specification specification = new Specification(2020, "BMW", "M5");

        [ObservableProperty]
        public Equipment equipment = new Equipment("Wifi", "Oil");

        [ObservableProperty]
        public Photo photo = new Photo();

        [ObservableProperty]
        public Price price = new Price(18000, 20000);

        [ObservableProperty]
        public Appearance appearance = new Appearance("Black", "White", "Black", "Shit");

        [ObservableProperty]
        public Characteristics characteristics = new Characteristics("Diesel", 2, 120000, "Manual", "AWD", "Sedan", 5);

        [ObservableProperty]
        public Information information = new Information("Good car, but needs a lot of oil :(");

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
