using System;
using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Infrastructure.Data.Entities;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class EmployeeRepository : EfRepository<Employee, EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<IEnumerable<Employee>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<EmployeeEntity>, IEnumerable<Employee>>(
                await DbContext.Employees.ToListAsync());
        }

        public override async Task<IEnumerable<Employee>> GetPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));
            
            return Mapper.Map<IEnumerable<EmployeeEntity>, IEnumerable<Employee>>(
                await DbContext.Employees
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }
    }
}