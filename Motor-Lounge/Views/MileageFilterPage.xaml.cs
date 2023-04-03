using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class MileageFilterPage : ContentPage
{
	public MileageFilterPage(CatalogViewModel model)
	{
		InitializeComponent();
		BindingContext=model;
	}
}