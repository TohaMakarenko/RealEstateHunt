﻿using RealEstateHunt.Core;
using System.Collections.Generic;

namespace RealEstateHunt.Infrastructure.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        IEnumerable<Contact> FindByFullName(string firstName, string lastName);
        IEnumerable<Contact> FindByFullName(string fullName);
        IEnumerable<Contact> FindByFullNameLike(string fullNameSubstring);
    }
}
