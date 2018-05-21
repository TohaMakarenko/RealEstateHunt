using System.Collections.Generic;
using RealEstateHunt.Core;
using System.Linq;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class ContractRepository : EfRepository<Contract, ContractEntity>, IContractRepository
    {
        public ContractRepository(RehDbContext dbContext,
            IMapper<Contract, ContractEntity> toEntityMapper,
            IMapper<ContractEntity, Contract> fromEntityMapper)
            : base(dbContext, toEntityMapper, fromEntityMapper)
        {
        }

        public override IEnumerable<Contract> GetEntities()
        {
            return FromEntityMapper.MapCollection(DbContext.Contracts);
        }

        public override IEnumerable<Contract> GetPage(int pageNumber, int pageSize)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Contracts
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
