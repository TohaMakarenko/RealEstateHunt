using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Infrastructure.Repositories
{
    public interface IContactRepository : IRepository<ContactEntity>
    {
        IEnumerable<ContactEntity> FindByFullName(string firstName, string lastName);
        IEnumerable<ContactEntity> FindByFullName(string fullName);
        IEnumerable<ContactEntity> FindByFullNameLike(string fullNameSubstring);
    }
}
