using System.Collections.Generic;

namespace RealEstateHunt.Core.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        IEnumerable<District> FindByName(string name);
    }
}
