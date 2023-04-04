using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Services.Identity;
using Motor_Lounge.Services.MongoDB;
using Motor_Lounge.Services.Navigation;
using Motor_Lounge.Services.Settings;
using Motor_Lounge.Validations;
using Motor_Lounge.ViewModels.Base;
using System.Diagnostics;

namespace Motor_Lounge.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IMongoDBService _mongoDBService;
        private readonly IIdentityService _identityService;

        [ObservableProperty]
        private ValidatableObject<string> _userName = new();

        [ObservableProperty]
        ValidatableObject<string> _password = new();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(MockSignInCommand))]
        private bool _isValid;

        [ObservableProperty]
        private bool _isMock;

        [ObservableProperty]
        private bool _isLogin;


        public LoginViewModel(
            IMongoDBService mongoDBService, IIdentityService identityService,
            INavigationService navigationService, ISettingsService settingsService)
            : base(navigationService)
        {
            _settingsService = settingsService;
            _mongoDBService = mongoDBService;
            _identityService = identityService;

            InvalidateMock();
        }

        public override void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            base.ApplyQueryAttributes(query);

            if (query.ValueAsBool("Logout") == true)
            {
                PerformLogout();
            }
        }

        public override Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        [RelayCommand(CanExecute = nameof(IsValid))]
        private async Task MockSignInAsync()
        {
            await IsBusyFor(
                async () =>
                {
                    bool isAuthenticated = false;

                    try
                    {
                        await Task.Delay(10);

                        isAuthenticated = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[SignIn] Error signing in: {ex}");
                    }

                    if (isAuthenticated)
                    {
                        //_settingsService.AuthAccessToken = GlobalSetting.Instance.AuthAccessToken;

                        await NavigationService.NavigateToAsync("//Main/Catalog");
                    }
                });
        }

        [RelayCommand]
        private async Task SignInAsync()
        {
            await IsBusyFor(
                async () =>
                {
                    await Task.Delay(10);

                    //LoginUrl = _identityService.CreateAuthorizationRequest();

                    IsValid = true;
                    IsLogin = true;
                });
        }

        [RelayCommand]
        private void /*Task*/ RegisterAsync()
        {
            //TODO
        }

        [RelayCommand]
        private void PerformLogout()
        {
            var authIdToken = _settingsService.AuthIdToken;
            var logoutRequest = _identityService.CreateLogoutRequest(authIdToken);

            if (!string.IsNullOrEmpty(logoutRequest))
            {
                // Logout
                //LoginUrl = logoutRequest;
            }

            if (_settingsService.UseMocks)
            {
                _settingsService.AuthAccessToken = string.Empty;
                _settingsService.AuthIdToken = string.Empty;
            }

            UserName.Value = string.Empty;
            Password.Value = string.Empty;
        }

        [RelayCommand]
        private async Task NavigateAsync(string url)
        {
            //TODO
        }

        [RelayCommand]
        private Task SettingsAsync()
        {
            return NavigationService.NavigateToAsync("Settings");
        }

        [RelayCommand]
        private void Validate()
        {
            IsValid = UserName.Validate() && Password.Validate();
        }

        private void AddValidations()
        {
            UserName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
        }

        public void InvalidateMock()
        {
            IsMock = _settingsService.UseMocks;
        }
    }
}
