using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Services;
using Motor_Lounge.ViewModels.Base;
using System.Collections.ObjectModel;

namespace Motor_Lounge.ViewModels
{

    public partial class FilterViewModel : BaseViewModel
    {
        private ICarService carService;
        public ObservableCollection<Car> FilteredCars { get; set; } = new();
        public List<Car> Cars { get; set; } = new();

        public FilterViewModel(ICarService _carService)
        {
            carService = _carService;
        }

        [ObservableProperty]
        public string selectedCarBrand = "Any";

        [ObservableProperty]
        public string selectedCarBodyType = "Any";

        [ObservableProperty]
        public string selectedCarDriveType = "Any";

        [ObservableProperty]
        public string selectedCarColor = "Any";

        [ObservableProperty]
        public long selectedStartYear = 2000;

        [ObservableProperty]
        public long selectedEndYear = 2023;

        [ObservableProperty]
        public long selectedStartPrice = 0;

        [ObservableProperty]
        public long selectedEndPrice = 200000;

        [ObservableProperty]
        public bool isAnyTransmission = true;

        [ObservableProperty]
        public bool isAutomaticTransmission = false;

        [ObservableProperty]
        public bool isManualTransmission = false;

        [ObservableProperty]
        public long selectedStartMilleage = 0;

        [ObservableProperty]
        public long selectedEndMilleage = 320000;

        public ObservableCollection<string> CarBrands { get; set; } = new();
        public ObservableCollection<long> Years { get; set; } = new ObservableCollection<long>()
        {
            2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023
        };
        public ObservableCollection<long> Prices { get; set; } = new ObservableCollection<long>()
        {
            0, 2000, 4000, 6000, 8000, 10000, 12000, 14000, 16000, 18000, 20000, 24000, 28000, 32000, 40000, 50000, 60000, 70000, 80000, 90000, 100000, 120000, 140000, 160000, 180000, 200000
        };

        public ObservableCollection<string> CarBodyTypes { get; set; } = new();
        public ObservableCollection<string> CarDriveTypes { get; set; } = new();
        public ObservableCollection<long> Milleages { get; set; } = new ObservableCollection<long>()
        {
            0, 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000, 120000, 140000, 160000, 180000, 200000, 240000, 280000, 320000
        };
        public ObservableCollection<string> CarColors { get; set; } = new();

        [RelayCommand]
        public async void FilterCars()
        {
            var cars = Cars;
            FilteredCars = new ObservableCollection<Car>(Cars.Where(car =>
                (SelectedCarBrand == "Any" || car.Specification.Brand == SelectedCarBrand) &&
                (SelectedCarBodyType == "Any" || car.Characteristics.BodyType == SelectedCarBodyType) &&
                (SelectedCarDriveType == "Any" || car.Characteristics.DriveType == SelectedCarDriveType) &&
                (SelectedCarColor == "Any" || car.Appearance.Color == SelectedCarColor) &&
                (car.Specification.Year >= SelectedStartYear && car.Specification.Year <= SelectedEndYear) &&
                (car.Price.IndividualPrice >= SelectedStartPrice && car.Price.IndividualPrice <= SelectedEndPrice) &&
                (!IsAnyTransmission && IsAutomaticTransmission && car.Characteristics.GearboxType == "Automatic" ||
                 !IsAnyTransmission && IsManualTransmission && car.Characteristics.GearboxType == "Manual" ||
                 IsAnyTransmission) &&
                (car.Characteristics.Milleage >= SelectedStartMilleage && car.Characteristics.Milleage <= SelectedEndMilleage) &&
                (SelectedStartYear <= SelectedEndYear) &&
                (SelectedStartPrice <= SelectedEndPrice) &&
                (SelectedStartMilleage <= SelectedEndMilleage)
            ).ToList());
            Cars = cars;
        }

        [RelayCommand]
        public void Refresh()
        {
            HashSet<string> uniqueBrands = new HashSet<string>();
            HashSet<string> uniqueColors = new HashSet<string>();
            HashSet<string> uniqueBodytypes = new HashSet<string>();
            HashSet<string> uniqueDrivetypes = new HashSet<string>();

            foreach (Car car in Cars)
            {
                uniqueBrands.Add(car.Specification.Brand);
                uniqueColors.Add(car.Appearance.CarColor);
                uniqueBodytypes.Add(car.Characteristics.BodyType);
                uniqueDrivetypes.Add(car.Characteristics.DriveType);
            }

            uniqueBrands.Add("Any");
            uniqueColors.Add("Any");
            uniqueBodytypes.Add("Any");
            uniqueDrivetypes.Add("Any");

            CarBrands = new ObservableCollection<string>(uniqueBrands.ToList());
            CarColors = new ObservableCollection<string>(uniqueColors.ToList());
            CarBodyTypes = new ObservableCollection<string>(uniqueBodytypes.ToList());
            CarDriveTypes = new ObservableCollection<string>(uniqueDrivetypes.ToList());
        }

    }
}

