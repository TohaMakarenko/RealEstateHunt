using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class EmployeeRepository : EfRepository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<EmployeeEntity> GetEntities()
        {
            return DbContext.Employees;
        }

        public override IEnumerable<EmployeeEntity> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Employees
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
