using System;
using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Infrastructure.Data.Entities;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class RealEstateRepository : EfRepository<RealEstate, RealEstateEntity>, IRealEstateRepository
    {
        public RealEstateRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override IQueryable<RealEstateEntity> IncludeEntities(IQueryable<RealEstateEntity> dbSet)
        {
            return dbSet
                .Include(e => e.City)
                .Include(e => e.District)
                .Include(e => e.Type);
        }

        protected override IQueryable<RealEstateEntity> IncludeCollections(IQueryable<RealEstateEntity> dbSet)
        {
            return dbSet.Include(e => e.Offers);
        }

        public override async Task<RealEstate> FindByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return Mapper.Map<RealEstateEntity, RealEstate>(
                await IncludeCollections(IncludeEntities(DbContext.RealEstates))
                    .FirstOrDefaultAsync(e => e.Id == id));
        }

        public override async Task<IEnumerable<RealEstate>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await IncludeEntities(DbContext.RealEstates).ToListAsync());
        }

        public override async Task<IEnumerable<RealEstate>> GetPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await IncludeEntities(DbContext.RealEstates)
                    .OrderByDescending(e => e.Id)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }

        public async Task<IEnumerable<RealEstate>> FindByCityNameAsync(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName)) throw new ArgumentNullException(nameof(cityName));

            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await IncludeEntities(DbContext.RealEstates)
                    .Where(re => re.City.Name == cityName)
                    .ToListAsync());
        }

        public async Task<IEnumerable<RealEstate>> FindByCityAndDistrictNameAsync(string cityName, string districtName)
        {
            if (string.IsNullOrWhiteSpace(cityName)) throw new ArgumentNullException(nameof(cityName));
            if (string.IsNullOrWhiteSpace(districtName)) throw new ArgumentNullException(nameof(districtName));

            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await IncludeEntities(DbContext.RealEstates)
                    .Where(re => re.City.Name == cityName &&
                                 re.District.Name == districtName)
                    .ToListAsync());
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesByTypeAsync(RealEstateType realEstateType)
        {
            return GetRealEstatesByTypeAsync(realEstateType.Id);
        }

        public async Task<IEnumerable<RealEstate>> GetRealEstatesByTypeAsync(int realEstateTypeId)
        {
            if (realEstateTypeId <= 0) throw new ArgumentOutOfRangeException(nameof(realEstateTypeId));

            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await IncludeEntities(DbContext.RealEstates)
                    .Where(re => re.TypeId == realEstateTypeId)
                    .ToListAsync());
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesByTypePageAsync(RealEstateType realEstateType,
            int pageNumber,
            int pageSize)
        {
            if (realEstateType == null) throw new ArgumentNullException(nameof(realEstateType));
            return GetRealEstatesByTypePageAsync(realEstateType.Id, pageNumber, pageSize);
        }

        public async Task<IEnumerable<RealEstate>> GetRealEstatesByTypePageAsync(int realEstateTypeId, int pageNumber,
            int pageSize)
        {
            if (pageNumber < 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await IncludeEntities(DbContext.RealEstates)
                    .Where(re => re.TypeId == realEstateTypeId)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPriceAsync(OrderDirection orderDirection)
        {
            return GetOrderedAsync(IncludeEntities(DbContext.RealEstates), re => re.Price, orderDirection);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPricePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            if (pageNumber < 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return GetOrderedPageAsync(IncludeEntities(DbContext.RealEstates), re => re.Price, pageNumber, pageSize,
                orderDirection);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesOrderByTypeAsync(OrderDirection orderDirection)
        {
            return GetOrderedAsync(IncludeEntities(DbContext.RealEstates), re => re.Type.Name, orderDirection);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesOrderByTypePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            if (pageNumber < 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return GetOrderedPageAsync(IncludeEntities(DbContext.RealEstates), re => re.Type.Name, pageNumber, pageSize,
                orderDirection);
        }

        public async Task<IEnumerable<RealEstate>> SearchRealEstatesAsync(string keyWord)
        {
            if (string.IsNullOrWhiteSpace(keyWord)) throw new ArgumentNullException(nameof(keyWord));

            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await IncludeEntities(DbContext.RealEstates)
                    .Where(re => re.Name.Contains(keyWord)
                                 || keyWord.Contains(re.Name)
                                 || re.City.Name.Contains(keyWord)
                                 || keyWord.Contains(re.City.Name)
                                 || re.District.Name.Contains(keyWord)
                                 || keyWord.Contains(re.District.Name))
                    .ToListAsync());
        }

        public async Task<IEnumerable<RealEstate>> GetDesiredRealEstatesForClientAsync(int clientId)
        {
            var client = await DbContext.Contacts.FindAsync(clientId);
            if (client == null) {
                return null;
            }

            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await DbContext.RealEstates
                    .Where(re => re.TypeId == client.PreferredTypeId
                                 && re.Price < client.PreferredPrice)
                    .ToListAsync());
        }
    }
}