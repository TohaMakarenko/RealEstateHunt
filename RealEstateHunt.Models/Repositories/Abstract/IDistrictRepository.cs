using System.Collections.Generic;

namespace RealEstateHunt.Models.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        IEnumerable<District> FindByName(string name);
    }
}
