using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Entities.Helpers;
using Motor_Lounge.Entities.Users;
using Motor_Lounge.Services;
using Motor_Lounge.ViewModels.Base;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Motor_Lounge.ViewModels
{
    public partial class MainViewModel : BaseViewModel, IQueryAttributable, INotifyPropertyChanged
    {
        private readonly IUserService userService;

        public readonly IApplicationService applicationService;

        private readonly IInformationService informationService;

        public event PropertyChangedEventHandler PropertyChanged;

        User selectedObject;

        public ObservableCollection<Information> News { get; set; } = new();

        public  MainViewModel(IUserService service, IInformationService _informationService, IApplicationService applicationService)
        {
            userService = service;
            informationService = _informationService;
            this.applicationService = applicationService;
        }

        [ObservableProperty]
        public string greetings;

        public User SelectedObject
        {
            get => selectedObject;
            set
            {
                selectedObject = value;
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        public async void GetNews()
        {
            var news = await informationService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                News.Clear();
                foreach (var news_ in news)
                {
                    News.Add(news_);
                }
            });
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            SelectedObject = query["User"] as User;
            
            Greetings = "Welcome, " + SelectedObject.UserName;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
