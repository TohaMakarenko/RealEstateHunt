using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    public class RealEstateRepository : EfRepository<RealEstate>, IRealEstateRepository
    {
        public RealEstateRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<RealEstate> GetEntities()
        {
            return DbContext.RealEstates;
        }

        public override IEnumerable<RealEstate> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.RealEstates
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<RealEstate> FindByCityName(string cityName)
        {
            return DbContext.RealEstates
                .Where(re => re.City.Name == cityName);
        }

        public IEnumerable<RealEstate> FindByCityAndDistrictName(string cityName, string districtName)
        {
            return DbContext.RealEstates
                .Where(re => re.City.Name == cityName &&
                re.District.Name == districtName);
        }
    }
}
