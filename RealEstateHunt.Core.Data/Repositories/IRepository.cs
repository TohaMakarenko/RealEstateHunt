using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task<IEnumerable<T>> GetPageAsync(int pageNumber, int pageSize);
        Task<T> FindByIdAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void Remove(T entity);
        void Save();
        Task SaveAsync();
    }
}
