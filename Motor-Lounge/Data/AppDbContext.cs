using Microsoft.EntityFrameworkCore;
using Motor_Lounge.Entities.Converters;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Entities.Helpers;
using Motor_Lounge.Entities.Users;

namespace Motor_Lounge.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars => Set<Car>();

        public DbSet<User> Users => Set<User>();

        public DbSet<Information> news => Set<Information>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Car>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Car>().Property(x => x.Photos).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Appearance).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Characteristics).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Information).IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.HashedPassword).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Salt).IsRequired();*/

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


            //for offers on main page
            modelBuilder.Entity<Information>().Property(x => x.Info).IsRequired();
        }
    }
}
