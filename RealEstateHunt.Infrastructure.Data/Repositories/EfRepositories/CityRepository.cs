using System;
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
    public class CityRepository : EfRepository<City, CityEntity>, ICityRepository
    {
        public CityRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<IEnumerable<City>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<CityEntity>, IEnumerable<City>>(await DbContext.Cities.ToListAsync());
        }

        public override async Task<IEnumerable<City>> GetPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));
            
            return Mapper.Map<IEnumerable<CityEntity>, IEnumerable<City>>(
                await DbContext.Cities
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync());
        }
    }
}
