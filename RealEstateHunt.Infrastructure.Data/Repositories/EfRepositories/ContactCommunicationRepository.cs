using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Data.Repositories;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class ContactCommunicationRepository : EfRepository<ContactCommunication, ContactCommunicationEntity>, IContactCommunicationRepository
    {
        public ContactCommunicationRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<ContactCommunication> GetEntities()
        {
            return mapper.Map<IEnumerable<ContactCommunicationEntity>, IEnumerable<ContactCommunication>>(DbContext.ContactCommunications);
        }

        public override IEnumerable<ContactCommunication> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<ContactCommunicationEntity>, IEnumerable<ContactCommunication>>(DbContext.ContactCommunications
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
