using System;
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

        protected override IQueryable<OfferEntity> IncludeEntities(IQueryable<OfferEntity> dbSet)
        {
            return dbSet
                .Include(e => e.Contact)
                .Include(e => e.RealEstate);
        }

        public override async Task<Offer> FindByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return Mapper.Map<OfferEntity, Offer>(
                await IncludeCollections(IncludeEntities(DbContext.Offers.AsNoTracking()))
                    .FirstOrDefaultAsync(e => e.Id == id));
        }

        public async Task<bool> GetCanAddOfferToClientAsync(int clientId, int maxOffers)
        {
            return await DbContext.Offers.Where(o => o.ContactId == clientId).Where(o => !o.IsDeclined)
                       .CountAsync() < maxOffers;
        }

        public override async Task<IEnumerable<Offer>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<OfferEntity>, IEnumerable<Offer>>(
                await IncludeEntities(DbContext.Offers).ToListAsync());
        }

        public override async Task<IEnumerable<Offer>> GetPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return Mapper.Map<IEnumerable<OfferEntity>, IEnumerable<Offer>>(
                await IncludeEntities(DbContext.Offers)
                    .OrderByDescending(e => e.Id)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }
    }
}