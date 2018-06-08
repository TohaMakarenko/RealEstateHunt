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
    public class DistrictRepository : EfRepository<District, DistrictEntity>, IDistrictRepository
    {
        public DistrictRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override IQueryable<DistrictEntity> IncludeEntities(IQueryable<DistrictEntity> dbSet)
        {
            return dbSet
                .Include(c => c.City);
        }

        protected override IQueryable<DistrictEntity> IncludeCollections(IQueryable<DistrictEntity> dbSet)
        {
            return dbSet
                .Include(c => c.Contacts)
                .Include(c => c.RealEstates);
        }

        public override async Task<District> FindByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return Mapper.Map<DistrictEntity, District>(
                await IncludeCollections(IncludeEntities(DbContext.Districts))
                    .FirstOrDefaultAsync(e => e.Id == id));
        }

        public override async Task<IEnumerable<District>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<DistrictEntity>, IEnumerable<District>>(
                await DbContext.Districts.ToListAsync());
        }

        public override async Task<IEnumerable<District>> GetPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return Mapper.Map<IEnumerable<DistrictEntity>, IEnumerable<District>>(
                await IncludeEntities(DbContext.Districts)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }

        public async Task<IEnumerable<District>> FindByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            return Mapper.Map<IEnumerable<DistrictEntity>, IEnumerable<District>>(
                await IncludeEntities(DbContext.Districts)
                    .Where(d => d.Name == name)
                    .ToArrayAsync());
        }
    }
}