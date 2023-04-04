using Motor_Lounge.Models.Users;

namespace Motor_Lounge.Services;

public interface IUserService
{
    Task<User> GetUserById(string id);
    Task<User> GetUserByEmail(string email);
    Task<List<User>> GetUsers();
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(string id);
}