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
    public class RealEstateTypeRepository : EfRepository<RealEstateType, RealEstateTypeEntity>,
        IRealEstateTypeRepository
    {
        public RealEstateTypeRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<IEnumerable<RealEstateType>> GetEntitiesAsync()
        {
            return mapper.Map<IEnumerable<RealEstateTypeEntity>, IEnumerable<RealEstateType>>(
                await DbContext.RealEstateTypes
                    .ToListAsync());
        }

        public override async Task<IEnumerable<RealEstateType>> GetPageAsync(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<RealEstateTypeEntity>, IEnumerable<RealEstateType>>(
                await DbContext.RealEstateTypes
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }
    }
}