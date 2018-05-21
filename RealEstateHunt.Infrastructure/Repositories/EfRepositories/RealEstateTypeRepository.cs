using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class RealEstateTypeRepository : EfRepository<RealEstateType, RealEstateTypeEntity>, IRealEstateTypeRepository
    {
        public RealEstateTypeRepository(RehDbContext dbContext,
            ICollectionMapper<RealEstateType, RealEstateTypeEntity> toEntityMapper,
            ICollectionMapper<RealEstateTypeEntity, RealEstateType> fromEntityMapper)
            : base(dbContext, toEntityMapper, fromEntityMapper)
        {
        }

        public override IEnumerable<RealEstateType> GetEntities()
        {
            return FromEntityMapper.MapCollection(DbContext.RealEstateTypes);
        }

        public override IEnumerable<RealEstateType> GetPage(int pageNumber, int pageSize)
        {
            return FromEntityMapper.MapCollection(
                DbContext.RealEstateTypes
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
