using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RealEstateHunt.Core.Data;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Exceptions;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public abstract class EfRepository<T, TEntity> : IRepository<T>
        where T : class
        where TEntity : class
    {
        protected IMapper mapper;

        public RehDbContext DbContext { get; protected set; }

        public EfRepository(RehDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
        }

        protected virtual async Task<IEnumerable<T>> GetOrderedAsync<TKey>(DbSet<TEntity> dbSet,
            Expression<Func<TEntity, TKey>> keySelector,
            OrderDirection orderDirection)
        {
            return mapper.Map<IEnumerable<TEntity>, IEnumerable<T>>(
                orderDirection == OrderDirection.Asc
                    ? await dbSet.OrderBy(keySelector).ToListAsync()
                    : await dbSet.OrderByDescending(keySelector).ToListAsync());
        }

        protected virtual async Task<IEnumerable<T>> GetOrderedPageAsync<TKey>(DbSet<TEntity> dbSet,
            Expression<Func<TEntity, TKey>> keySelector,
            int pageNumber, int pageSize, OrderDirection orderDirection)
        {
            var pagableResult = dbSet
                .Skip(pageNumber * pageSize)
                .Take(pageSize);

            return mapper.Map<IEnumerable<TEntity>, IEnumerable<T>>(
                orderDirection == OrderDirection.Asc
                    ? await pagableResult.OrderBy(keySelector).ToListAsync()
                    : await pagableResult.OrderByDescending(keySelector).ToListAsync());
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public abstract Task<IEnumerable<T>> GetEntitiesAsync();

        public abstract Task<IEnumerable<T>> GetPageAsync(int pageNumber, int pageSize);

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return mapper.Map<TEntity, T>(await DbContext.FindAsync<TEntity>(id));
        }

        public virtual void Add(T entity)
        {
            DbContext.Add<TEntity>(mapper.Map<T, TEntity>(entity));
        }

        public virtual void Update(T entity)
        {
            var entry = DbContext.Entry<TEntity>(mapper.Map<T, TEntity>(entity));
            if (entry == null)
                throw new EntityNotFoundException(entity, "Can not update record because it was not found");
            entry.State = EntityState.Modified;
        }

        public virtual void Remove(int id)
        {
            var entity = DbContext.Find<TEntity>(id);
            if (entity == null)
                throw new EntityNotFoundException("Can not remove record because it was not found");
            DbContext.Remove<TEntity>(entity);
        }

        public void Remove(T entity)
        {
            DbContext.Remove<TEntity>(mapper.Map<T, TEntity>(entity));
        }
    }
}