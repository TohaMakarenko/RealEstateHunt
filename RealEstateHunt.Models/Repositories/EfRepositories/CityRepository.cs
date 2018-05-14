using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    public class CityRepository : EfRepository<City>, ICityRepository
    {
        public CityRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<City> GetEntities()
        {
            return DbContext.Cities;
        }

        public override IEnumerable<City> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Cities
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
