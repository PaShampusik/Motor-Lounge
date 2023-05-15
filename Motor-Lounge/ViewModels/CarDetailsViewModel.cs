using CommunityToolkit.Mvvm.ComponentModel;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Services;
using System.ComponentModel;

namespace Motor_Lounge.ViewModels
{
    public partial class CarDetailsViewModel : ObservableObject, IQueryAttributable, INotifyPropertyChanged
    {
        public readonly ICarService carService;

        Car selectedObject;

        public CarDetailsViewModel(ICarService service)
        {
            carService = service;
        }

        public Car SelectedObject
        {
            get => selectedObject;
            set
            {
                selectedObject = value;
                OnPropertyChanged();
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            SelectedObject = query["Car"] as Car;
        }       
    }
}
