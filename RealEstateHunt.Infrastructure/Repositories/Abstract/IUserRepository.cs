using RealEstateHunt.Core;
using System.Collections.Generic;

namespace RealEstateHunt.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> FindByName(string name);
    }
}
