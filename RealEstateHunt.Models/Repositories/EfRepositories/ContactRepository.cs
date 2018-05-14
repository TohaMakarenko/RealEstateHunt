using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    public class ContactRepository : EfRepository<Contact>, IContactRepository
    {
        public ContactRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Contact> GetEntities()
        {
            return DbContext.Contacts;
        }

        public override IEnumerable<Contact> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Contacts
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<Contact> FindByFullName(string firstName, string lastName)
        {
            return DbContext.Contacts
                .Where(c =>
                   c.FirstName == firstName &&
                   c.LastName == lastName);
        }

        public IEnumerable<Contact> FindByFullName(string fullName)
        {
            return DbContext.Contacts
                .Where(c =>
                (c.FirstName + c.LastName) == fullName.Replace(" ", string.Empty));
        }

        public IEnumerable<Contact> FindByFullNameLike(string fullNameSubstring)
        {
            return DbContext.Contacts
                .Where(c =>
                (c.FirstName + c.LastName).Contains(fullNameSubstring.Replace(" ", string.Empty)));
        }
    }
}
