using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    public class EmployeeRepository : EfRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Employee> GetEntities()
        {
            return DbContext.Employees;
        }

        public override IEnumerable<Employee> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Employees
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
