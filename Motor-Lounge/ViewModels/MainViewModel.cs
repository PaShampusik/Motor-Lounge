using CommunityToolkit.Mvvm.ComponentModel;
using Motor_Lounge.Entities.Users;
using Motor_Lounge.Services;
using Motor_Lounge.ViewModels.Base;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Motor_Lounge.ViewModels
{
    public partial class MainViewModel : BaseViewModel, IQueryAttributable, INotifyPropertyChanged
    {
        private readonly IUserService userService;

        public event PropertyChangedEventHandler PropertyChanged;

        User selectedObject;

        public  MainViewModel(IUserService service)
        {
            userService = service;
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

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            SelectedObject = query["User"] as User;
            Greetings = "Welcome, " + SelectedObject.UserName;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
