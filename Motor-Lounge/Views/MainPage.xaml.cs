using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class MainPage : ContentPage
{
	private MainViewModel viewModel;

	private CarViewModel carViewModel;

	public MainPage(MainViewModel _viewModel, CarViewModel _carViewModel)
	{
		InitializeComponent();
		viewModel = _viewModel;
		carViewModel = _carViewModel;
		carViewModel.GetCars();
		viewModel.GetNews();
		BindingContext = viewModel;
	}

    public async void AccountExit(object sender, EventArgs args)
    {
        viewModel.SelectedObject = null;
        await Shell.Current.GoToAsync($"LoginPage");
    }
}

