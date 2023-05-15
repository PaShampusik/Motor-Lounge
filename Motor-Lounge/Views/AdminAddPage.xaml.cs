using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class AdminAddPage : ContentPage
{
    private AddViewModel viewModel;

    private CarViewModel carViewModel;
	public AdminAddPage(AddViewModel _viewModel, CarViewModel _carViewModel)
	{
		InitializeComponent();

		viewModel = _viewModel;
		carViewModel = _carViewModel;
		BindingContext = viewModel;
	}

	public async void Save(object sender, EventArgs args)
	{
		await viewModel.Save();
		carViewModel.Cars.Clear();
		carViewModel.GetCars();
        await Shell.Current.GoToAsync("CarPage");
    }
}