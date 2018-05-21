using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Data.Repositories;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
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
