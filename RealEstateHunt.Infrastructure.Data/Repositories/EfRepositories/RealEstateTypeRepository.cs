using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Repositories;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class RealEstateTypeRepository : EfRepository<RealEstateType, RealEstateTypeEntity>, IRealEstateTypeRepository
    {
        public RealEstateTypeRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<RealEstateType> GetEntities()
        {
            return mapper.Map<IEnumerable<RealEstateTypeEntity>, IEnumerable<RealEstateType>>(DbContext.RealEstateTypes);
        }

        public override IEnumerable<RealEstateType> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<RealEstateTypeEntity>, IEnumerable<RealEstateType>>(
                DbContext.RealEstateTypes
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
