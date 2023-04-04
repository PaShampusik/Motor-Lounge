using Motor_Lounge.ViewModels;

namespace Motor_Lounge.Views;

public partial class MileageFilterPage : ContentPage
{
	public MileageFilterPage(MileageFilterViewModel model)
	{
		InitializeComponent();
		BindingContext=model;
	}
}