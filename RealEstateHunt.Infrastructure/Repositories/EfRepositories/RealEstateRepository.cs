using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class RealEstateRepository : EfRepository<RealEstate, RealEstateEntity>, IRealEstateRepository
    {
        public RealEstateRepository(RehDbContext dbContext,
            IMapper<RealEstate, RealEstateEntity> toEntityMapper,
            IMapper<RealEstateEntity, RealEstate> fromEntityMapper)
            : base(dbContext, toEntityMapper, fromEntityMapper)
        {
        }

        public override IEnumerable<RealEstate> GetEntities()
        {
            return FromEntityMapper.MapCollection(DbContext.RealEstates);
        }

        public override IEnumerable<RealEstate> GetPage(int pageNumber, int pageSize)
        {
            return FromEntityMapper.MapCollection(
                DbContext.RealEstates
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }

        public IEnumerable<RealEstate> FindByCityName(string cityName)
        {
            return FromEntityMapper.MapCollection(
                DbContext.RealEstates
                .Where(re => re.City.Name == cityName));
        }

        public IEnumerable<RealEstate> FindByCityAndDistrictName(string cityName, string districtName)
        {
            return FromEntityMapper.MapCollection(
                DbContext.RealEstates
                .Where(re => re.City.Name == cityName &&
                re.District.Name == districtName));
        }
    }
}
