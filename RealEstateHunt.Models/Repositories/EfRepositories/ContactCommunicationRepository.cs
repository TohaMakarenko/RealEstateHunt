using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    public class ContactCommunicationRepository : EfRepository<ContactCommunication>, IContactCommunicationRepository
    {
        public ContactCommunicationRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<ContactCommunication> GetEntities()
        {
            return DbContext.ContactCommunications;
        }

        public override IEnumerable<ContactCommunication> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.ContactCommunications
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }
    }
}
