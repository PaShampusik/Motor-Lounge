using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Services;
using System.Collections.ObjectModel;


namespace Motor_Lounge.ViewModels
{
    public partial class CarViewModel : ObservableObject
    {
        public readonly ICarService carService;
        public ObservableCollection<Car> Cars { get; set; } = new();

        public bool IsAdmin { get; set; } = false;

        public CarViewModel(ICarService _carService)
        {
            carService = _carService;
        }

        [RelayCommand]
        public async void GetCars()
        {
            var cars = await carService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Cars.Clear();
                foreach (var car in cars)
                {
                    Cars.Add(car);
                }
            });
        }

        [RelayCommand]
        public async void GoToFilterPage()
        {
            await Shell.Current.GoToAsync($"FilterPage");
        }

        [RelayCommand]
        public async void GoToCarDetailsPage(Car car)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Car", car}
            };
            if (IsAdmin == false)
            {
                await Shell.Current.GoToAsync($"CarDetailsPage", parameters);
            }
            else
            {
                await Shell.Current.GoToAsync($"AdminCarDetailsPage", parameters);
            }
        }
    }
}
