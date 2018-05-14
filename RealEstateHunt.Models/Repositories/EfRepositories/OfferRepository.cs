using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    public class OfferRepository : EfRepository<Offer>, IOfferRepository
    {
        public OfferRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Offer> GetEntities()
        {
            return DbContext.Offers;
        }

        public override IEnumerable<Offer> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Offers
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
