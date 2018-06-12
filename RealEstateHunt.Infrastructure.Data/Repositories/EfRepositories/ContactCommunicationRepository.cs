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
    public class ContactCommunicationRepository : EfRepository<ContactCommunication, ContactCommunicationEntity>,
        IContactCommunicationRepository
    {
        public ContactCommunicationRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override IQueryable<ContactCommunicationEntity> IncludeEntities(
            IQueryable<ContactCommunicationEntity> dbSet)
        {
            return dbSet
                .Include(e => e.Contact);
        }
        
        public override async Task<ContactCommunication> FindByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return Mapper.Map<ContactCommunicationEntity, ContactCommunication>(
                await IncludeEntities(DbContext.ContactCommunications).FirstOrDefaultAsync(e => e.Id == id));
        }
        
        public override async Task<IEnumerable<ContactCommunication>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<ContactCommunicationEntity>, IEnumerable<ContactCommunication>>(
                await DbContext.ContactCommunications
                    .ToListAsync());
        }

        public override async Task<IEnumerable<ContactCommunication>> GetPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return Mapper.Map<IEnumerable<ContactCommunicationEntity>, IEnumerable<ContactCommunication>>(
                await DbContext
                    .ContactCommunications
                    .OrderByDescending(e=>e.Id)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }
    }
}