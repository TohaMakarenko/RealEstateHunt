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
        public CityRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override IQueryable<CityEntity> IncludeCollections(IQueryable<CityEntity> dbSet)
        {
            return dbSet
                .Include(e => e.Contacts)
                .Include(e => e.Districts)
                .Include(e => e.RealEstates);
        }

        public override async Task<City> FindByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return Mapper.Map<CityEntity, City>(
                await IncludeCollections(DbContext.Cities).FirstOrDefaultAsync(e => e.Id == id));
        }

        public override async Task<IEnumerable<City>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<CityEntity>, IEnumerable<City>>(await DbContext.Cities.ToListAsync());
        }

        public override async Task<IEnumerable<City>> GetPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return Mapper.Map<IEnumerable<CityEntity>, IEnumerable<City>>(
                await DbContext.Cities
                    .OrderByDescending(e=>e.Id)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }
    }
}