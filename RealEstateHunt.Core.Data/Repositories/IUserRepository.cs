using System.Collections.Generic;

namespace RealEstateHunt.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> FindByName(string name);
    }
}
