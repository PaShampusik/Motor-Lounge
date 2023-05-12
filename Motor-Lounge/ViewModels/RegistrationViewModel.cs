using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Motor_Lounge.Models.Users;
using Motor_Lounge.Services;
using Motor_Lounge.ViewModels.Base;
using System.Security.Cryptography;
using System.Text;

namespace Motor_Lounge.ViewModels
{
    public partial class RegistrationViewModel : BaseViewModel
    {
        public readonly IUserService _userService;

        public RegistrationViewModel(IUserService setService)
        {
            _userService = setService;
        }

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public string repeatpassword;

        [RelayCommand]
        public async Task Register()
        {
            if (Name != null && Email != null && Password != null && Repeatpassword != null) 
            {
                if (Password != Repeatpassword)
                {
                    await Application.Current.MainPage.DisplayAlert("Unable to register!", "Passwords don't match!", "Ok");
                }
                else
                {
                    var salt = RandomNumberGenerator.GetBytes(32);
                    await _userService.AddAsync(new User(Name, Email, GenerateSaltedHash(Encoding.UTF8.GetBytes(Password), salt), salt));
                    await Shell.Current.GoToAsync("..");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Unable to register!", "Not all fields are filled", "Ok");
            }
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
    }
}
