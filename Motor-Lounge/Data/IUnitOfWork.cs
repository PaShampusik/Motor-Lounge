using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Entities.Helpers;
using Motor_Lounge.Entities.Users;
using Application = Motor_Lounge.Entities.Users.Application;

namespace Motor_Lounge.Data
{
    public interface IUnitOfWork
    {
        IRepository<User> userRepository { get; }

        IRepository<Car> carRepository { get; }

        IRepository<Information> newsRepository { get; }

        IRepository<Application> applicationRepository { get; }

        public Task RemoveDatbaseAsync();

        public Task CreateDatabaseAsync();

        public Task SaveAllAsync();

    }
}
