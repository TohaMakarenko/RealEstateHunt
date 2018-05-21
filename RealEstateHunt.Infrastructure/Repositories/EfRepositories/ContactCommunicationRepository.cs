using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class ContactCommunicationRepository : EfRepository<ContactCommunication, ContactCommunicationEntity>, IContactCommunicationRepository
    {
        public ContactCommunicationRepository(RehDbContext dbContext,
            ICollectionMapper<ContactCommunication, ContactCommunicationEntity> toEntityMapper,
            ICollectionMapper<ContactCommunicationEntity, ContactCommunication> fromEntityMapper)
            : base(dbContext, toEntityMapper, fromEntityMapper)
        {
        }

        public override IEnumerable<ContactCommunication> GetEntities()
        {
            return FromEntityMapper.MapCollection(DbContext.ContactCommunications);
        }

        public override IEnumerable<ContactCommunication> GetPage(int pageNumber, int pageSize)
        {
            return FromEntityMapper.MapCollection(DbContext.ContactCommunications
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
