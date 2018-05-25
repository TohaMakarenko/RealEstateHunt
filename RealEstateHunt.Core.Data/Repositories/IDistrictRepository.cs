using System.Collections.Generic;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        IEnumerable<District> FindByName(string name);
    }
}
