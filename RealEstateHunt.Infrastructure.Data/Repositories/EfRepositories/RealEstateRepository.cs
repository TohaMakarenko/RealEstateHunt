using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Repositories;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class RealEstateRepository : EfRepository<RealEstate, RealEstateEntity>, IRealEstateRepository
    {
        public RealEstateRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<RealEstate> GetEntities()
        {
            return mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(DbContext.RealEstates);
        }

        public override IEnumerable<RealEstate> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                DbContext.RealEstates
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize));
        }

        public IEnumerable<RealEstate> FindByCityName(string cityName)
        {
            return mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                DbContext.RealEstates
                    .Where(re => re.City.Name == cityName));
        }

        public IEnumerable<RealEstate> FindByCityAndDistrictName(string cityName, string districtName)
        {
            return mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                DbContext.RealEstates
                    .Where(re => re.City.Name == cityName &&
                                 re.District.Name == districtName));
        }

        public IEnumerable<RealEstate> GetRealEstatesByType(RealEstateType realEstateType)
        {
            return mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                DbContext.RealEstates.Where(re => re.TypeId == realEstateType.Id));
        }

        public IEnumerable<RealEstate> GetRealEstatesByTypePage(RealEstateType realEstateType, int pageNumber,
            int pageSize)
        {
            return mapper.Map<IEnumerable<RealEstateEntity>, IEnumerable<RealEstate>>(
                DbContext.RealEstates
                    .Where(re => re.TypeId == realEstateType.Id)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize));
        }

        public IEnumerable<RealEstate> GetRealEstatesOrderByPrice(OrderDirection orderDirection)
        {
            return GetOrdered(DbContext.RealEstates, re => re.Price, orderDirection);
        }

        public IEnumerable<RealEstate> GetRealEstatesOrderByPricePage(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return GetOrderedPage(DbContext.RealEstates, re => re.Price, pageNumber, pageSize, orderDirection);
        }
    }
}