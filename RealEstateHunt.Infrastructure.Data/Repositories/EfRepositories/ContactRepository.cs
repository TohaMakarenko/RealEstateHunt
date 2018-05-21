using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Repositories;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class ContactRepository : EfRepository<Contact, ContactEntity>, IContactRepository
    {
        public ContactRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<Contact> GetEntities()
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(DbContext.Contacts);
        }

        public override IEnumerable<Contact> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                DbContext.Contacts
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }

        public IEnumerable<Contact> FindByFullName(string firstName, string lastName)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                DbContext.Contacts
                .Where(c =>
                   c.FirstName == firstName &&
                   c.LastName == lastName));
        }

        public IEnumerable<Contact> FindByFullName(string fullName)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                DbContext.Contacts
                .Where(c =>
                (c.FirstName + c.LastName) == fullName.Replace(" ", string.Empty)));
        }

        public IEnumerable<Contact> FindByFullNameLike(string fullNameSubstring)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                DbContext.Contacts
                .Where(c =>
                (c.FirstName + c.LastName).Contains(fullNameSubstring.Replace(" ", string.Empty))));
        }
    }
}
