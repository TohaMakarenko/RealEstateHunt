using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class CityRepository : EfRepository<City, CityEntity>, ICityRepository
    {
        public CityRepository(RehDbContext dbContext,
            IMapper<City, CityEntity> toEntityMapper,
            IMapper<CityEntity, City> fromEntityMapper)
            : base(dbContext, toEntityMapper, fromEntityMapper)
        {
        }

        public override IEnumerable<City> GetEntities()
        {
            return FromEntityMapper.MapCollection(DbContext.Cities);
        }

        public override IEnumerable<City> GetPage(int pageNumber, int pageSize)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Cities
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
