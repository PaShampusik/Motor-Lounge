using CoreData;

namespace Motor_Lounge.Services.User
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync(string authToken);
    }
}