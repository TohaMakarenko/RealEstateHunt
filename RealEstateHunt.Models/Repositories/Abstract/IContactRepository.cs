using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Models.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        IEnumerable<Contact> FindByFullName(string firstName, string lastName);
        IEnumerable<Contact> FindByFullName(string fullName);
        IEnumerable<Contact> FindByFullNameLike(string fullNameSubstring);
    }
}
