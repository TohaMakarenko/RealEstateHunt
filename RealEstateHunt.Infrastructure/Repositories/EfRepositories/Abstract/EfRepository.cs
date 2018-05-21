using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public abstract class EfRepository<T, TEntity> : IRepository<T>
        where T : class
        where TEntity : class
    {
        protected IMapper<T, TEntity> ToEntityMapper;
        protected IMapper<TEntity, T> FromEntityMapper;

        public RehDbContext DbContext { get; protected set; }

        public EfRepository(RehDbContext dbContext,
            IMapper<T, TEntity> toEntityMapper,
            IMapper<TEntity, T> fromEntityMapper)
        {
            DbContext = dbContext;
            ToEntityMapper = toEntityMapper;
            FromEntityMapper = fromEntityMapper;
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
            return FromEntityMapper.Map(DbContext.Find<TEntity>(id));
        }

        public virtual void Add(T entity)
        {
            DbContext.Add<TEntity>(ToEntityMapper.Map(entity));
        }

        public virtual void Update(T entity)
        {
            var entry = DbContext.Entry<TEntity>(ToEntityMapper.Map(entity));
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
            DbContext.Remove<TEntity>(ToEntityMapper.Map(entity));
        }
    }
}
