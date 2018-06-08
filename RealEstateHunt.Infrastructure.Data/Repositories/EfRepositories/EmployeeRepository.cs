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

        protected override IQueryable<EmployeeEntity> IncludeEntities(IQueryable<EmployeeEntity> dbSet)
        {
            return dbSet
                .Include(e => e.Contact);
        }

        protected override IQueryable<EmployeeEntity> IncludeCollections(IQueryable<EmployeeEntity> dbSet)
        {
            return dbSet
                .Include(e => e.Contracts);
        }

        public override async Task<Employee> FindByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return Mapper.Map<EmployeeEntity, Employee>(
                await IncludeCollections(IncludeEntities(DbContext.Employees))
                    .FirstOrDefaultAsync(e => e.Id == id));
        }

        public override async Task<IEnumerable<Employee>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<EmployeeEntity>, IEnumerable<Employee>>(
                await IncludeEntities(DbContext.Employees).ToListAsync());
        }

        public override async Task<IEnumerable<Employee>> GetPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return Mapper.Map<IEnumerable<EmployeeEntity>, IEnumerable<Employee>>(
                await IncludeEntities(DbContext.Employees)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }
    }
}