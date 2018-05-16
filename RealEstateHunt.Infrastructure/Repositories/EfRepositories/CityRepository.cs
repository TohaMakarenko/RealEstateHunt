using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class CityRepository : EfRepository<CityEntity>, ICityRepository
    {
        public CityRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<CityEntity> GetEntities()
        {
            return DbContext.Cities;
        }

        public override IEnumerable<CityEntity> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Cities
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
