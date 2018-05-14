using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Models.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> FindByName(string name);
    }
}
