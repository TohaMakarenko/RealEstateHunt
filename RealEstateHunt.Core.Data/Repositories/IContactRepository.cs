using System.Collections.Generic;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        IEnumerable<Contact> GetClientsOrderByFirstName(OrderDirection orderDirection);
        IEnumerable<Contact> GetClientsOrderByFirstNamePage(int pageNumber, int pageSize, OrderDirection orderDirection);
        IEnumerable<Contact> GetClientsOrderByLastName(OrderDirection orderDirection);
        IEnumerable<Contact> GetClientsOrderByLastNamePage(int pageNumber, int pageSize, OrderDirection orderDirection);
        IEnumerable<Contact> GetClientsOrderByBankAccountNumber(OrderDirection orderDirection);

        IEnumerable<Contact> GetClientsOrderByBankAccountNumberPage(int pageNumber, int pageSize,
            OrderDirection orderDirection);

        IEnumerable<Contact> FindByFullName(string firstName, string lastName);
        IEnumerable<Contact> FindByFullName(string fullName);
        IEnumerable<Contact> FindByFullNameLike(string fullNameSubstring);
    }
}