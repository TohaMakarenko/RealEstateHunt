using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    public class RealEstateTypeRepository : EfRepository<RealEstateType>, IRealEstateTypeRepository
    {
        public RealEstateTypeRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<RealEstateType> GetEntities()
        {
            return DbContext.RealEstateTypes;
        }

        public override IEnumerable<RealEstateType> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.RealEstateTypes
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
