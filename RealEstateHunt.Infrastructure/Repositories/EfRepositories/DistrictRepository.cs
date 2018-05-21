using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class DistrictRepository : EfRepository<District, DistrictEntity>, IDistrictRepository
    {
        public DistrictRepository(RehDbContext dbContext,
            IMapper<District, DistrictEntity> toEntityMapper,
            IMapper<DistrictEntity, District> fromEntityMapper)
            : base(dbContext, toEntityMapper, fromEntityMapper)
        {
        }

        public override IEnumerable<District> GetEntities()
        {
            return FromEntityMapper.MapCollection(DbContext.Districts);
        }

        public override IEnumerable<District> GetPage(int pageNumber, int pageSize)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Districts
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }

        public IEnumerable<District> FindByName(string name)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Districts
                .Where(d => d.Name == name));
        }
    }
}
