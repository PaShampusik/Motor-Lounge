using Motor_Lounge.Models.Token;

namespace Motor_Lounge.Services.Identity
{
    internal class IdentityService : IIdentityService
    {
        public string CreateAuthorizationRequest()
        {
            throw new NotImplementedException();
        }

        public string CreateLogoutRequest(string token)
        {
            throw new NotImplementedException();
        }

        public Task<UserToken> GetTokenAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
