using System;
using System.Collections.Generic;
using RealEstateHunt.Core.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Infrastructure.Data.Entities;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class ContractRepository : EfRepository<Contract, ContractEntity>, IContractRepository
    {
        public ContractRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<IEnumerable<Contract>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<ContractEntity>, IEnumerable<Contract>>(
                await DbContext.Contracts.ToListAsync());
        }

        public override async Task<IEnumerable<Contract>> GetPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));
            
            return Mapper.Map<IEnumerable<ContractEntity>, IEnumerable<Contract>>(
                await DbContext.Contracts
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToArrayAsync());
        }
    }
}