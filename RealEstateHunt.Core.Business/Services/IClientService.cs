using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Business.Services
{
    public interface IClientService
    {
        Task<Contact> AddClientAsync(Contact contact);
        Task RemoveClientAsync(int id);
        Task RemoveClientAsync(Contact client);
        Task EditClient(Contact client);
        Task<Contact> GetClientAsync(int id);
        Task<IEnumerable<Contact>> GetClientsAsync();
        Task<IEnumerable<Contact>> GetClientsPageAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Contact>> GetClientsOrderByFirstNameAsync(OrderDirection orderDirection);
        Task<IEnumerable<Contact>> GetClientsOrderByFirstNamePageAsync(int pageNumber, int pageSize, OrderDirection orderDirection);
        Task<IEnumerable<Contact>> GetClientsOrderByLastNameAsync(OrderDirection orderDirection);
        Task<IEnumerable<Contact>> GetClientsOrderByLastNamePageAsync(int pageNumber, int pageSize, OrderDirection orderDirection);
        Task<IEnumerable<Contact>> GetClientsOrderByBankAccountNumberAsync(OrderDirection orderDirection);
        Task<IEnumerable<Contact>> GetClientsOrderByBankAccountNumberPageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection);
    }
}