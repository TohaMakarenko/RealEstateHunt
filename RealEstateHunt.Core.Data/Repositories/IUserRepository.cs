using System.Collections.Generic;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> FindByName(string name);
    }
}
