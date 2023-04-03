using Motor_Lounge.Models.Token;

namespace Motor_Lounge.Services.Identity;

public interface IIdentityService
{
    string CreateAuthorizationRequest();
    string CreateLogoutRequest(string token);
    Task<UserToken> GetTokenAsync(string code);
}