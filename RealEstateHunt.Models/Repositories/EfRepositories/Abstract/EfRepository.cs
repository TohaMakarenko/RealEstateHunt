using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    public abstract class EfRepository<T> : IRepository<T> where T : class
    {
        public RehDbContext DbContext { get; protected set; }

        public EfRepository(RehDbContext dbContext)
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
            return DbContext.Find<T>(id);
        }

        public virtual void Add(T entity)
        {
            DbContext.Add<T>(entity);
        }

        public virtual void Update(T entity)
        {
            var entry = DbContext.Entry<T>(entity);
            if (entry == null)
                throw new EntityNotFoundException(entity, "Can not update record because it was not found");
            entry.State = EntityState.Modified;
        }

        public virtual void Remove(int id)
        {
            var entity = DbContext.Find<T>(id);
            if (entity == null)
                throw new EntityNotFoundException("Can not remove record because it was not found");
            DbContext.Remove<T>(entity);
        }

        public void Remove(T entity)
        {
            DbContext.Remove<T>(entity);
        }
    }
}
