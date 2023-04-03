namespace Motor_Lounge.Services;

public interface IDialogService
{
    Task ShowAlertAsync(string message, string title, string buttonLabel);
}