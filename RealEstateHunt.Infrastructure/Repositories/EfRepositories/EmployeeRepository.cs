using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class EmployeeRepository : EfRepository<Employee, EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(RehDbContext dbContext,
            ICollectionMapper<Employee, EmployeeEntity> toEntityMapper,
            ICollectionMapper<EmployeeEntity, Employee> fromEntityMapper)
            : base(dbContext, toEntityMapper, fromEntityMapper)
        {
        }

        public override IEnumerable<Employee> GetEntities()
        {
            return FromEntityMapper.MapCollection(DbContext.Employees);
        }

        public override IEnumerable<Employee> GetPage(int pageNumber, int pageSize)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Employees
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
