namespace Motor_Lounge.Services.Settings;

public interface ISettingsService
{
    string AuthAccessToken { get; set; }
    string AuthIdToken { get; set; }
    bool UseMocks { get; set; }
}