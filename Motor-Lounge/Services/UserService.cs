using Motor_Lounge.Data;
using Motor_Lounge.Models.Users;

namespace Motor_Lounge.Services
{
    class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork _unit)
        {
            unitOfWork = _unit;
        }

        public Task AddAsync(User item)
        {
            unitOfWork.userRepository.AddAsync(item);
            return unitOfWork.SaveAllAsync();
        }

        public void DeleteAsync(User item)
        {
            unitOfWork.userRepository.DeleteAsync(item);
            unitOfWork.SaveAllAsync();
        }

        public Task<IReadOnlyList<User>> GetAllAsync()
        {
            return unitOfWork.userRepository.ListAllAsync();
        }

        public Task<User> GetByIdAsync(int id)
        {
            return unitOfWork.userRepository.GetByIdAsync(id);
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return (unitOfWork.userRepository as UserRepository).GetByEmailAsync(email);
        }

        public Task UpdateAsync(User item)
        {
            return unitOfWork.userRepository.UpdateAsync(item);
        }
    }
}
