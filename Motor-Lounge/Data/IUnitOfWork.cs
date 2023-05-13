using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Entities.Users;

namespace Motor_Lounge.Data
{
    public interface IUnitOfWork
    {
        IRepository<User> userRepository { get; }

        IRepository<Car> carRepository { get; }

        public Task RemoveDatbaseAsync();

        public Task CreateDatabaseAsync();

        public Task SaveAllAsync();

    }
}
