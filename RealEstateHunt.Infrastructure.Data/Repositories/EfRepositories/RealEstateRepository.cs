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

        public override async Task<IEnumerable<RealEstate>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await DbContext.RealEstates.ToListAsync());
        }

        public override async Task<IEnumerable<RealEstate>> GetPageAsync(int pageNumber, int pageSize)
        {
            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await DbContext.RealEstates
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }

        public async Task<IEnumerable<RealEstate>> FindByCityNameAsync(string cityName)
        {
            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await DbContext.RealEstates
                    .Where(re => re.City.Name == cityName)
                    .ToListAsync());
        }

        public async Task<IEnumerable<RealEstate>> FindByCityAndDistrictNameAsync(string cityName, string districtName)
        {
            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await DbContext.RealEstates
                    .Where(re => re.City.Name == cityName &&
                                 re.District.Name == districtName)
                    .ToListAsync());
        }

        public async Task<IEnumerable<RealEstate>> GetRealEstatesByTypeAsync(RealEstateType realEstateType)
        {
            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await DbContext.RealEstates
                    .Where(re => re.TypeId == realEstateType.Id)
                    .ToListAsync());
        }

        public async Task<IEnumerable<RealEstate>> GetRealEstatesByTypePageAsync(RealEstateType realEstateType,
            int pageNumber,
            int pageSize)
        {
            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await DbContext.RealEstates
                    .Where(re => re.TypeId == realEstateType.Id)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPriceAsync(OrderDirection orderDirection)
        {
            return GetOrderedAsync(DbContext.RealEstates, re => re.Price, orderDirection);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPricePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return GetOrderedPageAsync(DbContext.RealEstates, re => re.Price, pageNumber, pageSize, orderDirection);
        }

        public async Task<IEnumerable<RealEstate>> SearchRealEstatesAsync(string keyWord)
        {
            return Mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                await DbContext.RealEstates
                    .Where(re => re.Name.Contains(keyWord)
                                 || keyWord.Contains(re.Name)
                                 || re.City.Name.Contains(keyWord)
                                 || keyWord.Contains(re.City.Name)
                                 || re.District.Name.Contains(keyWord)
                                 || keyWord.Contains(re.District.Name)
                                 || re.Street.Contains(keyWord)
                                 || keyWord.Contains(re.Street))
                    .ToListAsync());
        }
    }
}