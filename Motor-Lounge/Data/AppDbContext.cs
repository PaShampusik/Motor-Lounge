using Microsoft.EntityFrameworkCore;
using Motor_Lounge.Models.Cars;
using Motor_Lounge.Models.Users;

namespace Motor_Lounge.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars => Set<Car>();

        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Car>().Property(x => x.Photos).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Appearance).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Characteristics).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Information).IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.HashedPassword).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Salt).IsRequired();
        }
    }
}
