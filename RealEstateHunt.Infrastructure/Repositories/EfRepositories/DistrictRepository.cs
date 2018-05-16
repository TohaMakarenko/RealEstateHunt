using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class DistrictRepository : EfRepository<DistrictEntity>, IDistrictRepository
    {
        public DistrictRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<DistrictEntity> GetEntities()
        {
            return DbContext.Districts;
        }

        public override IEnumerable<DistrictEntity> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Districts
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<DistrictEntity> FindByName(string name)
        {
            return DbContext.Districts.Where(d => d.Name == name);
        }
    }
}
