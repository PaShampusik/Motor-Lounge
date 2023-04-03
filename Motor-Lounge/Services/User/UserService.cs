using CoreData;
using Motor_Lounge.Services.RequestProvider;

namespace Motor_Lounge.Services.User;

public class UserService : IUserService
{
    private readonly IRequestProvider _requestProvider;

    public UserService(IRequestProvider requestProvider)
    {
        _requestProvider = requestProvider;
    }

    public async Task<UserInfo> GetUserInfoAsync(string authToken)
    {
        //TO DO
        return null;
    }
}