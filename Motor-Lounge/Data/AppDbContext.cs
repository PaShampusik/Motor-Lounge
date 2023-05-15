using Microsoft.EntityFrameworkCore;
using Motor_Lounge.Entities.Converters;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Entities.Helpers;
using Motor_Lounge.Entities.Users;
using Application = Motor_Lounge.Entities.Users.Application;

namespace Motor_Lounge.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars => Set<Car>();

        public DbSet<User> Users => Set<User>();

        public DbSet<Information> News => Set<Information>();

        public DbSet<Application> Applications => Set<Application>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Car>()
        .Property(c => c.Price)
        .HasConversion(new PriceConverter());

            modelBuilder.Entity<Car>()
                .Property(c => c.Information)
                .HasConversion(new InformationConverter());

            modelBuilder.Entity<Car>()
                .Property(c => c.Photos)
                .HasConversion(new PhotosConverter());

            modelBuilder.Entity<Car>()
                .Property(c => c.Appearance)
                .HasConversion(new AppearanceConverter());

            modelBuilder.Entity<Car>()
                .Property(c => c.Characteristics)
                .HasConversion(new CharacteristicsConverter());

            modelBuilder.Entity<Car>()
                .Property(c => c.Equipment)
                .HasConversion(new EquipmentConverter());
            modelBuilder.Entity<Car>()
                .Property(c => c.Specification)
                .HasConversion(new SpecificationConverter());

            modelBuilder.Entity<Car>()
                .Property(c => c.Specification)
                .HasConversion(new SpecificationConverter());

            modelBuilder.Entity<Application>().Property(x => x.CarId).IsRequired();
            modelBuilder.Entity<Application>().Property(x => x.UserEmail).IsRequired();

            //for offers on main page
            modelBuilder.Entity<Information>().Property(x => x.Info).IsRequired();
        }
    }
}
