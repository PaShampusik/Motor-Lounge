using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class CarDetailsPage : ContentPage
{
	private CarDetailsViewModel viewModel;
	public CarDetailsPage(CarDetailsViewModel _viewModel)
	{
		InitializeComponent();
		viewModel = _viewModel;
		BindingContext = viewModel;
	}
}