using Motor_Lounge.Data;
using Motor_Lounge.Entities.Cars;

namespace Motor_Lounge.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork unitOfWork;

        public CarService(IUnitOfWork _unit)
        {
            unitOfWork = _unit;
        }

        public Task AddAsync(Car item)
        {
            unitOfWork.carRepository.AddAsync(item);
            return unitOfWork.SaveAllAsync();
        }

        public void DeleteAsync(Car item)
        {
            unitOfWork.carRepository.DeleteAsync(item);
            unitOfWork.SaveAllAsync();
        }

        public Task<IReadOnlyList<Car>> GetAllAsync()
        {
            return unitOfWork.carRepository.ListAllAsync();
        }

        public Task<Car> GetByIdAsync(int id)
        {
            return unitOfWork.carRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Car item)
        {
            return unitOfWork.carRepository.UpdateAsync(item);
        }
    }
}
