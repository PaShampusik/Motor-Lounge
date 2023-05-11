using Microsoft.EntityFrameworkCore;
using Motor_Lounge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> entities;

        public Repository(DbContext _dbContext)
        {
            dbContext = _dbContext;
            entities = dbContext.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await entities.AddAsync(entity, cancellationToken);
        }

        public void DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            entities.Remove(entity);
        }

        public async Task<T> FirstAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await entities.FirstAsync(filter, cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<T, object>>[]? includesProperties)
        {
            var query = entities.AsQueryable();
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.FirstAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await entities.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<T, object>>[]? includesProperties)
        {
            var query = entities.Where(filter);
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var old = await GetByIdAsync(entity.Id);
            dbContext.Entry(old).CurrentValues.SetValues(entity);
        }
    }
}
