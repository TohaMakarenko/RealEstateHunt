using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Models.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByName(string name);
    }
}
