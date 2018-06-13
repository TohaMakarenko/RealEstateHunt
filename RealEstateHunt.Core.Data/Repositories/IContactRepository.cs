using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetClientsOrderByFirstNameAsync(OrderDirection orderDirection);

        Task<IEnumerable<Contact>>
            GetClientsOrderByFirstNamePageAsync(int pageNumber, int pageSize, OrderDirection orderDirection);

        Task<IEnumerable<Contact>> GetClientsOrderByLastNameAsync(OrderDirection orderDirection);

        Task<IEnumerable<Contact>> GetClientsOrderByLastNamePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection);

        Task<IEnumerable<Contact>> GetClientsOrderByBankAccountNumberAsync(OrderDirection orderDirection);

        Task<IEnumerable<Contact>> GetClientsOrderByBankAccountNumberPageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection);

        Task<IEnumerable<Contact>> FindByFullNameAsync(string firstName, string lastName);
        Task<IEnumerable<Contact>> FindByFullNameAsync(string fullName);
        Task<IEnumerable<Contact>> FindByFullNameLikeAsync(string fullNameSubstring);

        Task<IEnumerable<Contact>> SearchContactsAsync(string keyWord);
        Task<IEnumerable<Contact>> ExtendedSearchContactsAsync(Contact contact);
        Task<IEnumerable<Contact>> GetAvailableForOfferClients(int maxOffers);
        Task<IEnumerable<Contact>> GetContactsWhichDesireRealEstateAsync(int realEstateid, int maxOffers);
    }
}