using System.Collections.Generic;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> FindByName(string name);
    }
}
