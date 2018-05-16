using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class ContractRepository : EfRepository<ContractEntity>, IContractRepository
    {
        public ContractRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<ContractEntity> GetEntities()
        {
            return DbContext.Contracts;
        }

        public override IEnumerable<ContractEntity> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Contracts
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
