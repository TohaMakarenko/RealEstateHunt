using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Models
{
    interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetEntities();
        T FindById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
