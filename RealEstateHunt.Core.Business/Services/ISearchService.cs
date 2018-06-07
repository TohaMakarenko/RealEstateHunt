using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Business.Models;
using RealEstateHunt.Core.Data;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Business.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<Contact>> SearchContactsAsync(string keyWord);
        Task<IEnumerable<RealEstate>> SearchRealEstatesAsync(string keyWord);
        Task<SearchResult> SearchAllAsync(string keyWord);
        Task<IEnumerable<Contact>> ExtendedSearchContactsAsync(Contact contact);
    }
}