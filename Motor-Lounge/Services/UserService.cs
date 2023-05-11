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
            return unitOfWork.userRepository.AddAsync(item);
        }

        public void DeleteAsync(User item)
        {
            unitOfWork.userRepository.DeleteAsync(item);
        }

        public Task<IReadOnlyList<User>> GetAllAsync()
        {
            return unitOfWork.userRepository.ListAllAsync();
        }

        public Task<User> GetByIdAsync(int id)
        {
            return unitOfWork.userRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(User item)
        {
            return unitOfWork.userRepository.UpdateAsync(item);
        }
    }
}
