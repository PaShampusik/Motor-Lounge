﻿using Microsoft.EntityFrameworkCore;
using Motor_Lounge.Entities;
using Motor_Lounge.Models.Cars;
using Motor_Lounge.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Data
{
    public class UserRepository : IRepository<User> 
    {
        private readonly DbContext dbContext;
        private readonly DbSet<User> entities;

        public UserRepository(DbContext _dbContext)
        {
            dbContext = _dbContext;
            entities = dbContext.Set<User>();
        }

        public async Task AddAsync(User entity, CancellationToken cancellationToken = default)
        {
            await entities.AddAsync(entity, cancellationToken);
        }

        public void DeleteAsync(User entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            entities.Remove(entity);
        }

        public async Task<User> FirstAsync(System.Linq.Expressions.Expression<Func<User, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await entities.FirstAsync(filter, cancellationToken);
        }

        public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<User, object>>[]? includesProperties)
        {
            var query = entities.AsQueryable();
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.FirstAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<User, object>>[]? includesProperties)
        {
            var query = entities.AsQueryable();
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.FirstAsync(e => e.Email == email, cancellationToken);
        }

        public async Task<IReadOnlyList<User>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await entities.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<User>> ListAsync(System.Linq.Expressions.Expression<Func<User, bool>> filter, CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<User, object>>[]? includesProperties)
        {
            var query = entities.Where(filter);
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            var old = await GetByIdAsync(entity.Id);
            dbContext.Entry(old).CurrentValues.SetValues(entity);
        }
    }


    public class CarRepository : IRepository<Car>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Car> entities;

        public CarRepository(DbContext _dbContext)
        {
            dbContext = _dbContext;
            entities = dbContext.Set<Car>();
        }

        public async Task AddAsync(Car entity, CancellationToken cancellationToken = default)
        {
            await entities.AddAsync(entity, cancellationToken);
        }

        public void DeleteAsync(Car entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            entities.Remove(entity);
        }

        public async Task<Car> FirstAsync(System.Linq.Expressions.Expression<Func<Car, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await entities.FirstAsync(filter, cancellationToken);
        }

        public async Task<Car> GetByIdAsync(int id, CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<Car, object>>[]? includesProperties)
        {
            var query = entities.AsQueryable();
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.FirstAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<Car>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await entities.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Car>> ListAsync(System.Linq.Expressions.Expression<Func<Car, bool>> filter, CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<Car, object>>[]? includesProperties)
        {
            var query = entities.Where(filter);
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Car entity, CancellationToken cancellationToken = default)
        {
            var old = await GetByIdAsync(entity.Id);
            dbContext.Entry(old).CurrentValues.SetValues(entity);
        }
    }
}
