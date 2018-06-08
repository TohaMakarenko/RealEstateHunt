using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Exceptions;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public abstract class EfRepository<T, TEntity> : IRepository<T>
        where T : class
        where TEntity : class
    {
        protected readonly IMapper Mapper;

        protected RehDbContext DbContext { get; set; }

        protected EfRepository(RehDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        protected virtual IQueryable<TEntity> IncludeEntities(IQueryable<TEntity> dbSet)
        {
            return dbSet;
        }
        
        protected virtual IQueryable<TEntity> IncludeCollections(IQueryable<TEntity> dbSet)
        {
            return dbSet;
        }

        protected virtual async Task<IEnumerable<T>> GetOrderedAsync<TKey>(IQueryable<TEntity> dbSet,
            Expression<Func<TEntity, TKey>> keySelector,
            OrderDirection orderDirection)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            var includeEntities = IncludeEntities(dbSet);
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<T>>(
                orderDirection == OrderDirection.Asc
                    ? await includeEntities.OrderBy(keySelector).ToListAsync()
                    : await includeEntities.OrderByDescending(keySelector).ToListAsync());
        }

        protected virtual async Task<IEnumerable<T>> GetOrderedPageAsync<TKey>(IQueryable<TEntity> dbSet,
            Expression<Func<TEntity, TKey>> keySelector,
            int pageNumber, int pageSize, OrderDirection orderDirection)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (pageNumber <= 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));
            var includeEntities = IncludeEntities(dbSet);
            var pagableResult = includeEntities
                .Skip(pageNumber * pageSize)
                .Take(pageSize);

            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<T>>(
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
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return Mapper.Map<TEntity, T>(await DbContext.FindAsync<TEntity>(id));
        }

        public virtual void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            DbContext.Add<TEntity>(Mapper.Map<T, TEntity>(entity));
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var entry = DbContext.Entry<TEntity>(Mapper.Map<T, TEntity>(entity));
            if (entry == null)
                throw new EntityNotFoundException(entity, "Can not update record because it was not found");
            entry.State = EntityState.Modified;
        }

        public virtual void Remove(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            var entity = DbContext.Find<TEntity>(id);
            if (entity == null)
                throw new EntityNotFoundException("Can not remove record because it was not found");
            DbContext.Remove<TEntity>(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            DbContext.Remove<TEntity>(Mapper.Map<T, TEntity>(entity));
        }
    }
}