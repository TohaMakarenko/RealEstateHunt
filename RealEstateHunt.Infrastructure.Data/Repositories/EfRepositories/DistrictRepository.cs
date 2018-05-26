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
    public class DistrictRepository : EfRepository<District, DistrictEntity>, IDistrictRepository
    {
        public DistrictRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<IEnumerable<District>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<DistrictEntity>, IEnumerable<District>>(
                await DbContext.Districts.ToListAsync());
        }

        public override async Task<IEnumerable<District>> GetPageAsync(int pageNumber, int pageSize)
        {
            return Mapper.Map<IEnumerable<DistrictEntity>, IEnumerable<District>>(
                await DbContext.Districts
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }

        public async Task<IEnumerable<District>> FindByNameAsync(string name)
        {
            return Mapper.Map<IEnumerable<DistrictEntity>, IEnumerable<District>>(
                await DbContext.Districts
                    .Where(d => d.Name == name)
                    .ToArrayAsync());
        }
    }
}