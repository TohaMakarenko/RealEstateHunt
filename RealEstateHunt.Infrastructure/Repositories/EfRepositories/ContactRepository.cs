using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class ContactRepository : EfRepository<ContactEntity>, IContactRepository
    {
        public ContactRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<ContactEntity> GetEntities()
        {
            return DbContext.Contacts;
        }

        public override IEnumerable<ContactEntity> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Contacts
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<ContactEntity> FindByFullName(string firstName, string lastName)
        {
            return DbContext.Contacts
                .Where(c =>
                   c.FirstName == firstName &&
                   c.LastName == lastName);
        }

        public IEnumerable<ContactEntity> FindByFullName(string fullName)
        {
            return DbContext.Contacts
                .Where(c =>
                (c.FirstName + c.LastName) == fullName.Replace(" ", string.Empty));
        }

        public IEnumerable<ContactEntity> FindByFullNameLike(string fullNameSubstring)
        {
            return DbContext.Contacts
                .Where(c =>
                (c.FirstName + c.LastName).Contains(fullNameSubstring.Replace(" ", string.Empty)));
        }
    }
}
