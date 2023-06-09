using Microsoft.Maui.Controls;
using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class CarPage : ContentPage
{
	private MainViewModel mainViewModel;
	private CarViewModel viewModel;
	public CarPage(CarViewModel _viewmodel, MainViewModel _userModel)
	{
        InitializeComponent();
		viewModel = _viewmodel;
		mainViewModel = _userModel;
		BindingContext = viewModel;
	}
    
    protected override void OnAppearing()
	{
		if (mainViewModel.SelectedObject.IsAdmin == true)
		{
			viewModel.IsAdmin = true;
		}
		else
		{
            viewModel.IsAdmin = false;
        }
    }
}