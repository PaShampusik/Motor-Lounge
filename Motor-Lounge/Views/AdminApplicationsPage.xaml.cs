using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class AdminApplicationsPage : ContentPage
{
    private ApplicationsViewModel viewModel;

    public AdminApplicationsPage(ApplicationsViewModel _viewModel)
    {
        InitializeComponent();

        viewModel = _viewModel;
        viewModel.GetApplications();
        BindingContext = viewModel;
    }
}