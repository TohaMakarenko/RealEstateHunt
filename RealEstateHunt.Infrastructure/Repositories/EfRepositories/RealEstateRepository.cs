using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class RealEstateRepository : EfRepository<RealEstateEntity>, IRealEstateRepository
    {
        public RealEstateRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<RealEstateEntity> GetEntities()
        {
            return DbContext.RealEstates;
        }

        public override IEnumerable<RealEstateEntity> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.RealEstates
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<RealEstateEntity> FindByCityName(string cityName)
        {
            return DbContext.RealEstates
                .Where(re => re.City.Name == cityName);
        }

        public IEnumerable<RealEstateEntity> FindByCityAndDistrictName(string cityName, string districtName)
        {
            return DbContext.RealEstates
                .Where(re => re.City.Name == cityName &&
                re.District.Name == districtName);
        }
    }
}
