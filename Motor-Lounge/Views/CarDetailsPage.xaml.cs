using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class CarDetailsPage : ContentPage
{
	private CarDetailsViewModel viewModel;

	private MainViewModel mainViewModel;

	public CarDetailsPage(CarDetailsViewModel _viewModel, MainViewModel _mainViewModel)
	{
		InitializeComponent();
		viewModel = _viewModel;
		mainViewModel = _mainViewModel;
		BindingContext = viewModel;
	}

	public async void CreateApplication(object sender, EventArgs e)
	{
		await mainViewModel.applicationService.AddAsync(new Entities.Users.Application(mainViewModel.SelectedObject.Email, viewModel.SelectedObject.Id));
		await Shell.Current.GoToAsync("..");
	}
}