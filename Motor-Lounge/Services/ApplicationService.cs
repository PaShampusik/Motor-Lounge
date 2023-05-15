using Motor_Lounge.Data;
using Application = Motor_Lounge.Entities.Users.Application;

namespace Motor_Lounge.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork unitOfWork;

        public ApplicationService(IUnitOfWork _unit)
        {
            unitOfWork = _unit;
        }

        public Task AddAsync(Application item)
        {
            unitOfWork.applicationRepository.AddAsync(item);
            return unitOfWork.SaveAllAsync();
        }

        public void DeleteAsync(Application item)
        {
            unitOfWork.applicationRepository.DeleteAsync(item);
            unitOfWork.SaveAllAsync();
        }

        public Task<IReadOnlyList<Application>> GetAllAsync()
        {
            return unitOfWork.applicationRepository.ListAllAsync();
        }

        public Task<Application> GetByIdAsync(int id)
        {
            return unitOfWork.applicationRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Application item)
        {
            return unitOfWork.applicationRepository.UpdateAsync(item);
        }
    }
}
