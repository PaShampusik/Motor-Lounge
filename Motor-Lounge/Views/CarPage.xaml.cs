using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class CarPage : ContentPage
{
	private CarViewModel viewModel;
	public CarPage(CarViewModel _viewmodel)
	{
		InitializeComponent();
		viewModel = _viewmodel;
		viewModel.GetCars();
		BindingContext = viewModel;
	}
}