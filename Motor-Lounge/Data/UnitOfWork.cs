using Motor_Lounge.Models.Cars;
using Motor_Lounge.Models.Users;

namespace Motor_Lounge.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        private readonly IRepository<Car> carRepository;

        private readonly IRepository<User> userRepository;

        public UnitOfWork(AppDbContext _context)
        {
            context = _context;
            carRepository = new Repository<Car>(context);
            userRepository = new Repository<User>(context);
        }

        IRepository<User> IUnitOfWork.userRepository => userRepository;

        IRepository<Car> IUnitOfWork.carRepository => carRepository;

        public async Task CreateDatabaseAsync()
        {
            await context.Database.EnsureCreatedAsync();
        }

        public async Task RemoveDatbaseAsync()
        {
            await context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
