using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        IEnumerable<UserEntity> FindByName(string name);
    }
}
