﻿using System.Collections.Generic;
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
            return mapper.Map<IEnumerable<ContractEntity>, IEnumerable<Contract>>(
                await DbContext.Contracts.ToListAsync());
        }

        public override async Task<IEnumerable<Contract>> GetPageAsync(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<ContractEntity>, IEnumerable<Contract>>(
                await DbContext.Contracts
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToArrayAsync());
        }
    }
}