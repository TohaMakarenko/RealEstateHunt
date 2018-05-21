using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

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

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public abstract IEnumerable<T> GetEntities();

        public abstract IEnumerable<T> GetPage(int pageNumber, int pageSize);

        public virtual T FindById(int id)
        {
            return mapper.Map<TEntity, T>(DbContext.Find<TEntity>(id));
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
