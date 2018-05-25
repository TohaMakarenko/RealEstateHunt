using System.Collections.Generic;
using RealEstateHunt.Core.Data;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Business.Services
{
    public interface IClientService
    {
        void AddClient(Contact contact);
        void RemoveClient(int id);
        void RemoveClient(Contact client);
        void EditClient(Contact client);
        Contact GetClient(int id);
        IEnumerable<Contact> GetClients();
        IEnumerable<Contact> GetClientsPage(int pageNumber, int pageSize);
        IEnumerable<Contact> GetClientsOrderByFirstName(OrderDirection orderDirection);
        IEnumerable<Contact> GetClientsOrderByFirstNamePage(int pageNumber, int pageSize, OrderDirection orderDirection);
        IEnumerable<Contact> GetClientsOrderByLastName(OrderDirection orderDirection);
        IEnumerable<Contact> GetClientsOrderByLastNamePage(int pageNumber, int pageSize, OrderDirection orderDirection);
        IEnumerable<Contact> GetClientsOrderByBankAccountNumber(OrderDirection orderDirection);
        IEnumerable<Contact> GetClientsOrderByBankAccountNumberPage(int pageNumber, int pageSize,
            OrderDirection orderDirection);
    }
}