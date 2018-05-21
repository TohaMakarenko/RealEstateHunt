using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Repositories;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
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
    }
}
