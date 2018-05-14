using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Models.Repositories
{
    interface IContactRepository : IRepository<Contact>
    {
        Contact FindByFullName(string firstName, string lastName);
        Contact FindByFullNameLike(string fullNameSubstring);
    }
}
