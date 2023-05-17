using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class FilterPage : ContentPage
{
	private FilterViewModel viewModel;
	private CarViewModel carViewModel;

	public FilterPage(FilterViewModel _viewModel, CarViewModel _carViewModel)
	{
		InitializeComponent();
		viewModel = _viewModel;
		carViewModel = _carViewModel;
		viewModel.Cars = carViewModel.Cars.ToList();
		viewModel.Refresh();
		BindingContext = viewModel;
	}

	async void OnButtonClicked(object sender, EventArgs args)
	{
		viewModel.FilterCars();
		carViewModel.Cars.Clear();
		foreach(var car in viewModel.FilteredCars) 
		{
            carViewModel.Cars.Add(car);
        }
        await Shell.Current.GoToAsync("..");
    }	
}


