using MongoDB.Driver;
using Motor_Lounge.Models.Users;
using Motor_Lounge.Services.MongoDB;

namespace Motor_Lounge.Services;
public class UserService : IUserService
{
    private readonly IMongoDBService _mongoDBService;

    public UserService(IMongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    public Task DeleteUser(string id)
    {
        throw new NotImplementedException();
    }

    /* public async Task<User> GetUserById(string id)
     {
         var filter = Builders<User>.Filter.Eq(u => u.Id, id);
         return await _mongoDBService.GetOne(filter);
     }

     public async Task<User> GetUserByEmail(string email)
     {
         var filter = Builders<User>.Filter.Eq(u => u.Email, email);
         return await _mongoDBService.GetOne(filter);
     }

     public async Task<List<User>> GetUsers()
     {
         return await _mongoDBService.GetAll();
     }

     public async Task CreateUser(User user)
     {
         await _mongoDBService.Insert(user);
     }

     public async Task UpdateUser(User user)
     {
         var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
         await _mongoDBService.Update(filter, user);
     }

     public async Task DeleteUser(string id)
     {
         var filter = Builders<User>.Filter.Eq(u => u.Id, id);
         await _mongoDBService.Delete(filter);
     }*/
}