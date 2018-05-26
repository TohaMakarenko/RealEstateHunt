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

        public override async Task<IEnumerable<ContactCommunication>> GetEntitiesAsync()
        {
            return mapper.Map<IEnumerable<ContactCommunicationEntity>, IEnumerable<ContactCommunication>>(
                await DbContext.ContactCommunications
                    .ToListAsync());
        }

        public override async Task<IEnumerable<ContactCommunication>> GetPageAsync(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<ContactCommunicationEntity>, IEnumerable<ContactCommunication>>(
                await DbContext
                    .ContactCommunications
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }
    }
}