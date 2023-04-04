using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Services.Navigation;
using Motor_Lounge.ViewModels.Base;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Motor_Lounge.ViewModels
{
    public class NewFilterViewModel : ViewModelBase
    {

        public NewFilterViewModel(INavigationService navigationService) : base(navigationService)
        {
            // Заполнение коллекций марок автомобилей, типов топлива и годов выпуска
            Brands = new ObservableCollection<string> { "Audi", "BMW", "Mercedes-Benz", "Volkswagen" };
            FuelTypes = new ObservableCollection<string> { "Бензин", "Дизель", "Электро" };
            Years = new ObservableCollection<int> { 2023, 2022, 2021, 2020, 2019, 2018, 2017, 2016, 2015 };

            // Задание начальных значений цены и объема двигателя
            MinPrice = 0;
            MaxPrice = 1000000;
            MinEngineVolume = 1.0;
            MaxEngineVolume = 3.0;

            ApplyFilterCommand = new RelayCommand(ApplyFilter);
        }
        public ObservableCollection<string> Brands { get; set; }

        public ObservableCollection<string> FuelTypes { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public ObservableCollection<int> Years { get; set; }

        public double MinEngineVolume { get; set; }

        public double MaxEngineVolume { get; set; }

        public ICommand ApplyFilterCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        private void ApplyFilter()
        {
            // Обработка нажатия на кнопку "Применить фильтр"
        }
    }
}


