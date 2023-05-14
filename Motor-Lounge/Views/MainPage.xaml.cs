using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class MainPage : ContentPage
{
	private MainViewModel viewModel;

	public MainPage(MainViewModel _viewModel)
	{
		InitializeComponent();
		viewModel = _viewModel;
		viewModel.GetNews();
		BindingContext = viewModel;
	}
}

