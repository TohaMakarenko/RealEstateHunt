using System.Collections.Generic;
using RealEstateHunt.Core.Data;

namespace RealEstateHunt.Core.Business.Services
{
    public interface ISearchService
    {
        IEnumerable<Contact> SearchContacts(string keyWord);
        IEnumerable<RealEstate> SearchRealEstates(string keyWord);
        IEnumerable<RealEstate> SearchAll(string keyWord);
        IEnumerable<Contact> ExtendedSearchContacts(Contact contact);
    }
}