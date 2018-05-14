using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    public class ContractRepository : EfRepository<Contract>, IContractRepository
    {
        public ContractRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Contract> GetEntities()
        {
            return DbContext.Contracts;
        }

        public override IEnumerable<Contract> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Contracts
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
