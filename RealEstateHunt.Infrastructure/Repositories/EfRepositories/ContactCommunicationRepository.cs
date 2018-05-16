using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class ContactCommunicationRepository : EfRepository<ContactCommunicationEntity>, IContactCommunicationRepository
    {
        public ContactCommunicationRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<ContactCommunicationEntity> GetEntities()
        {
            return DbContext.ContactCommunications;
        }

        public override IEnumerable<ContactCommunicationEntity> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.ContactCommunications
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
