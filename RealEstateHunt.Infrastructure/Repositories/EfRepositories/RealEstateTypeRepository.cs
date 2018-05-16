using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class RealEstateTypeRepository : EfRepository<RealEstateTypeEntity>, IRealEstateTypeRepository
    {
        public RealEstateTypeRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<RealEstateTypeEntity> GetEntities()
        {
            return DbContext.RealEstateTypes;
        }

        public override IEnumerable<RealEstateTypeEntity> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.RealEstateTypes
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
