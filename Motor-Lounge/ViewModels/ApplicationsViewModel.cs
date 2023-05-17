using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Services;
using Motor_Lounge.ViewModels.Base;
using System.Collections.ObjectModel;


namespace Motor_Lounge.ViewModels
{
    public partial class ApplicationsViewModel : BaseViewModel
    {
        public readonly IApplicationService applicationsService;
        public ObservableCollection<Motor_Lounge.Entities.Users.Application> Applications { get; set; } = new();

        public ApplicationsViewModel(IApplicationService _applicationsService)
        {
            applicationsService = _applicationsService;
        }

        public async void GetApplications()
        {
            var applications = await applicationsService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Applications.Clear();
                foreach (var application in applications)
                {
                    Applications.Add(application);
                }
            });
        }
    }
}
