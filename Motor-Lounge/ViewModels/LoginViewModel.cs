using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Services;
using Motor_Lounge.ViewModels.Base;
using System.Security.Cryptography;
using System.Text;

namespace Motor_Lounge.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {

        public readonly IUserService _userService;

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;

        [RelayCommand]
        public async void Login()
        {
            if (Email != null && Password != null)
            {
                if (_userService.GetByEmailAsync(Email).IsFaulted)
                {
                    await Application.Current.MainPage.DisplayAlert("Unable to login!", "Wrong Password or Email!", "Ok");
                    return;
                }
                var user = _userService.GetByEmailAsync(Email).Result;
                if (CompareByteArrays(GenerateSaltedHash(Encoding.UTF8.GetBytes(Password), user.Salt), user.HashedPassword))
                {
                    IDictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"User", user}
                    };
                    await Shell.Current.GoToAsync("//Home", parameters);
                    return;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Unable to login!", "Wrong Password or Email!", "Ok");
                    return;
                }
            }
            else
            {               
                await Application.Current.MainPage.DisplayAlert("Unable to login!", "Not all fields are filled!", "Ok");
                return;
            }
        }

        [RelayCommand]
        public async Task GoToRegistration()
        {
            await Shell.Current.GoToAsync($"RegistrationPage");
        }

        static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            var sha512 = SHA512.Create();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return sha512.ComputeHash(plainTextWithSaltBytes);
        }

        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
