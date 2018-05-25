using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Infrastructure.Data.Entities;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class DistrictRepository : EfRepository<District, DistrictEntity>, IDistrictRepository
    {
        public DistrictRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<District> GetEntities()
        {
            return mapper.Map<IEnumerable<DistrictEntity>, IEnumerable<District>>(DbContext.Districts);
        }

        public override IEnumerable<District> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<DistrictEntity>, IEnumerable<District>>(
                DbContext.Districts
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }

        public IEnumerable<District> FindByName(string name)
        {
            return mapper.Map<IEnumerable<DistrictEntity>, IEnumerable<District>>(
                DbContext.Districts
                .Where(d => d.Name == name));
        }
    }
}
