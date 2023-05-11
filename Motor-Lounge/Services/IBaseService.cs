using Motor_Lounge.Entities;

namespace Motor_Lounge.Services
{
    public interface IBaseService<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T item);

        Task UpdateAsync(T item);

        void DeleteAsync(T item);
    }
}
