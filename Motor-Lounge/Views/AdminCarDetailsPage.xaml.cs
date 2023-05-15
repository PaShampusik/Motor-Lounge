using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class AdminCarDetailsPage : ContentPage
{
    private CarDetailsViewModel viewModel;

    private CarViewModel carViewModel;
    public AdminCarDetailsPage(CarViewModel _carModel, CarDetailsViewModel _viewModel)
	{
		InitializeComponent();
        viewModel = _viewModel;
        carViewModel = _carModel;
        BindingContext = viewModel;
	}

    public async void Add(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AdminAddPage");
    }

    public async void Delete(object sender, EventArgs e)
    {
        viewModel.carService.DeleteAsync(viewModel.SelectedObject);
        carViewModel.Cars.Clear();
        carViewModel.GetCars();
        await Shell.Current.GoToAsync("..");
    }
}