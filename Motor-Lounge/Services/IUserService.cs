using Motor_Lounge.Entities.Users;

namespace Motor_Lounge.Services
{
    public interface IUserService : IBaseService<User>
    {
        public Task<User> GetByEmailAsync(string email);
    }
}
