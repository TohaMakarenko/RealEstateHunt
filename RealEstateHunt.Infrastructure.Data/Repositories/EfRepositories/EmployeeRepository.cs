﻿using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Repositories;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class EmployeeRepository : EfRepository<Employee, EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<Employee> GetEntities()
        {
            return mapper.Map<IEnumerable<EmployeeEntity>, IEnumerable<Employee>>(DbContext.Employees);
        }

        public override IEnumerable<Employee> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<EmployeeEntity>, IEnumerable<Employee>>(
                DbContext.Employees
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}