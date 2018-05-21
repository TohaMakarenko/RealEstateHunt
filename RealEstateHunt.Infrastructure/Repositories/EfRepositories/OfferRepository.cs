using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class OfferRepository : EfRepository<Offer, OfferEntity>, IOfferRepository
    {
        public OfferRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<Offer> GetEntities()
        {
            return mapper.Map<IEnumerable<OfferEntity>, IEnumerable<Offer>>(DbContext.Offers);
        }

        public override IEnumerable<Offer> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<OfferEntity>, IEnumerable<Offer>>(
                DbContext.Offers
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
