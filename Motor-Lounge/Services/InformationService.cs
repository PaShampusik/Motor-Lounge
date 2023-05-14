using Motor_Lounge.Data;
using Motor_Lounge.Entities.Helpers;

namespace Motor_Lounge.Services
{
    public class InformationService : IInformationService
    {
        private readonly IUnitOfWork unitOfWork;

        public InformationService(IUnitOfWork _unit)
        {
            unitOfWork = _unit;
        }

        public Task AddAsync(Information item)
        {
            unitOfWork.newsRepository.AddAsync(item);
            return unitOfWork.SaveAllAsync();
        }

        public void DeleteAsync(Information item)
        {
            unitOfWork.newsRepository.DeleteAsync(item);
            unitOfWork.SaveAllAsync();
        }

        public Task<IReadOnlyList<Information>> GetAllAsync()
        {
            return unitOfWork.newsRepository.ListAllAsync();
        }

        public Task<Information> GetByIdAsync(int id)
        {
            return unitOfWork.newsRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Information item)
        {
            return unitOfWork.newsRepository.UpdateAsync(item);
        }
    }
}
