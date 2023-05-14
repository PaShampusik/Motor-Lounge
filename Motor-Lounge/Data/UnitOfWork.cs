﻿using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Entities.Helpers;
using Motor_Lounge.Entities.Users;

namespace Motor_Lounge.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        private readonly IRepository<Car> carRepository;

        private readonly IRepository<User> userRepository;

        private readonly IRepository<Information> newsRepository;

        public UnitOfWork(AppDbContext _context)
        {
            context = _context;
            carRepository = new CarRepository(context);
            userRepository = new UserRepository(context);
            newsRepository = new InformationRepository(context);
        }

        IRepository<User> IUnitOfWork.userRepository => userRepository;

        IRepository<Car> IUnitOfWork.carRepository => carRepository;

        IRepository<Information> IUnitOfWork.newsRepository => newsRepository;

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
