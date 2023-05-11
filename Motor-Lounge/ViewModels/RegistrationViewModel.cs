using Motor_Lounge.Models.Users;
using Motor_Lounge.Services;
using Motor_Lounge.Services.Navigation;
using Motor_Lounge.ViewModels.Base;
using System.ComponentModel;

namespace Motor_Lounge.ViewModels
{
    internal class RegistrationViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private bool _isBusy;
        private bool _registrationSuccessful;

        public RegistrationViewModel(INavigationService navigationService, IUserService userService) : base(navigationService)
        {
            _userService = userService;           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
                }
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConfirmPassword)));
                }
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
                }
            }
        }

        public bool RegistrationSuccessful
        {
            get => _registrationSuccessful;
            set
            {
                if (_registrationSuccessful != value)
                {
                    _registrationSuccessful = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RegistrationSuccessful)));
                }
            }
        }

        public async Task Register()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    throw new ArgumentException("Email and password are required.");
                }

                if (Password != ConfirmPassword)
                {
                    throw new ArgumentException("Passwords do not match.");
                }

                var existingUser = await _userService.GetUserByEmail(Email);

                if (existingUser != null)
                {
                    throw new ArgumentException("A user with this email already exists.");
                }

                var user = new User
                {
                    Email = Email,
                    Password = Password // Password should be hashed in production code
                };

                await _userService.CreateUser(user);

                RegistrationSuccessful = true;
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
