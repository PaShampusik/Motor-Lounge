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
		BindingContext = viewModel;
	}
}


