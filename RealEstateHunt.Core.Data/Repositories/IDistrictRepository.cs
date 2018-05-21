using System.Collections.Generic;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        IEnumerable<District> FindByName(string name);
    }
}
