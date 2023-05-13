using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Motor_Lounge.ViewModels
{
    public partial class CarDetailsViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        private readonly ICarService carService;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
