using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class ContactRepository : EfRepository<Contact, ContactEntity>, IContactRepository
    {
        public ContactRepository(RehDbContext dbContext,
            IMapper<Contact, ContactEntity> toEntityMapper,
            IMapper<ContactEntity, Contact> fromEntityMapper)
            : base(dbContext, toEntityMapper, fromEntityMapper)
        {
        }

        public override IEnumerable<Contact> GetEntities()
        {
            return FromEntityMapper.MapCollection(DbContext.Contacts);
        }

        public override IEnumerable<Contact> GetPage(int pageNumber, int pageSize)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Contacts
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }

        public IEnumerable<Contact> FindByFullName(string firstName, string lastName)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Contacts
                .Where(c =>
                   c.FirstName == firstName &&
                   c.LastName == lastName));
        }

        public IEnumerable<Contact> FindByFullName(string fullName)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Contacts
                .Where(c =>
                (c.FirstName + c.LastName) == fullName.Replace(" ", string.Empty)));
        }

        public IEnumerable<Contact> FindByFullNameLike(string fullNameSubstring)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Contacts
                .Where(c =>
                (c.FirstName + c.LastName).Contains(fullNameSubstring.Replace(" ", string.Empty))));
        }
    }
}
