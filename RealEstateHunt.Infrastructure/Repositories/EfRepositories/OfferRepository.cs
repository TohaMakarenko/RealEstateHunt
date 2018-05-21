using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class OfferRepository : EfRepository<Offer, OfferEntity>, IOfferRepository
    {
        public OfferRepository(RehDbContext dbContext,
            IMapper<Offer, OfferEntity> toEntityMapper,
            IMapper<OfferEntity, Offer> fromEntityMapper)
            : base(dbContext, toEntityMapper, fromEntityMapper)
        {
        }

        public override IEnumerable<Offer> GetEntities()
        {
            return FromEntityMapper.MapCollection(DbContext.Offers);
        }

        public override IEnumerable<Offer> GetPage(int pageNumber, int pageSize)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Offers
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
