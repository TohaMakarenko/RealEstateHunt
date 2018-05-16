using System.Collections.Generic;

namespace RealEstateHunt.Infrastructure.Repositories
{
    public interface IDistrictRepository : IRepository<DistrictEntity>
    {
        IEnumerable<DistrictEntity> FindByName(string name);
    }
}
