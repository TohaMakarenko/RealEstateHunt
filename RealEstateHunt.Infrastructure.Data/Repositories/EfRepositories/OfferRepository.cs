using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Infrastructure.Data.Entities;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class OfferRepository : EfRepository<Offer, OfferEntity>, IOfferRepository
    {
        public OfferRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<IEnumerable<Offer>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<OfferEntity>, IEnumerable<Offer>>(
                await DbContext.Offers.ToListAsync());
        }

        public override async Task<IEnumerable<Offer>> GetPageAsync(int pageNumber, int pageSize)
        {
            return Mapper.Map<IEnumerable<OfferEntity>, IEnumerable<Offer>>(
                await DbContext.Offers
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }
    }
}