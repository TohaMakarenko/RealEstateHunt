using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class CityRepository : EfRepository<City, CityEntity>, ICityRepository
    {
        public CityRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<City> GetEntities()
        {
            return mapper.Map<IEnumerable<CityEntity>, IEnumerable<City>>(DbContext.Cities);
        }

        public override IEnumerable<City> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<CityEntity>, IEnumerable<City>>(
                DbContext.Cities
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
