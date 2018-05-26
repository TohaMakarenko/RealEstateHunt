using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> FindByNameAsync(string name);
    }
}
