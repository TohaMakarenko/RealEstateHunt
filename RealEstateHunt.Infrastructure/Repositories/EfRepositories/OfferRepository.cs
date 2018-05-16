using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class OfferRepository : EfRepository<OfferEntity>, IOfferRepository
    {
        public OfferRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<OfferEntity> GetEntities()
        {
            return DbContext.Offers;
        }

        public override IEnumerable<OfferEntity> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Offers
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
