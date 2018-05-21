using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetEntities();
        IEnumerable<T> GetPage(int pageNumber, int pageSize);
        T FindById(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void Remove(T entity);
        void Save();
        Task SaveAsync();
    }
}
