﻿using System.Collections.Generic;
using RealEstateHunt.Core.Data;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Infrastructure.Data.Entities;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class ContractRepository : EfRepository<Contract, ContractEntity>, IContractRepository
    {
        public ContractRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<Contract> GetEntities()
        {
            return mapper.Map<IEnumerable<ContractEntity>, IEnumerable<Contract>>(DbContext.Contracts);
        }

        public override IEnumerable<Contract> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<ContractEntity>, IEnumerable<Contract>>(
                DbContext.Contracts
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
