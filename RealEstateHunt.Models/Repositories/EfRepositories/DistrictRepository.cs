using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    public class DistrictRepository : EfRepository<District>, IDistrictRepository
    {
        public DistrictRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<District> GetEntities()
        {
            return DbContext.Districts;
        }

        public override IEnumerable<District> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Districts
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<District> FindByName(string name)
        {
            return DbContext.Districts.Where(d => d.Name == name);
        }
    }
}
