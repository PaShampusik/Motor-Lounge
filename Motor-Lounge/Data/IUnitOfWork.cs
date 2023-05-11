using Motor_Lounge.Models.Cars;
using Motor_Lounge.Models.Users;

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
