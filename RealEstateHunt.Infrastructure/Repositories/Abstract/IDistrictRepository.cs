using RealEstateHunt.Core;
using System.Collections.Generic;

namespace RealEstateHunt.Infrastructure.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        IEnumerable<District> FindByName(string name);
    }
}
