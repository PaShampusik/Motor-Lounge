﻿using Motor_Lounge.Entities;
using System.Linq.Expressions;

namespace Motor_Lounge.Data
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties);

        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        void DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task<T> FirstAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    }
}
