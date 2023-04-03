using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Services.Navigation;
using Motor_Lounge.ViewModels.Base;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Motor_Lounge.ViewModels
{
    internal class NewFilterViewModel : ViewModelBase
    {
        public NewFilterViewModel(INavigationService navigationService) : base(navigationService)
        { }
            // Коллекция марок автомобилей
            public ObservableCollection<string> Brands { get; set; }

            // Коллекция типов топлива
            public ObservableCollection<string> FuelTypes { get; set; }

            // Минимальная цена
            public int MinPrice { get; set; }

            // Максимальная цена
            public int MaxPrice { get; set; }

            // Коллекция годов выпуска автомобилей
            public ObservableCollection<int> Years { get; set; }

            // Минимальный объем двигателя
            public double MinEngineVolume { get; set; }

            // Максимальный объем двигателя
            public double MaxEngineVolume { get; set; }

            // Команда для применения фильтра
            public ICommand ApplyFilterCommand { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;

            public NewFilterViewModel()
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

                // Инициализация команды для применения фильтра
                ApplyFilterCommand = new RelayCommand(ApplyFilter);
            }

            private void ApplyFilter()
            {
                // Обработка нажатия на кнопку "Применить фильтр"
                // ...
            }

            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        
    }
}
    

