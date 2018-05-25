using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Infrastructure.Data.Entities;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class ContactRepository : EfRepository<Contact, ContactEntity>, IContactRepository
    {
        public ContactRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<Contact> GetEntities()
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(DbContext.Contacts);
        }

        public override IEnumerable<Contact> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                DbContext.Contacts
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize));
        }

        public IEnumerable<Contact> GetClientsOrderByFirstName(OrderDirection orderDirection)
        {
            return GetOrdered(DbContext.Contacts, c => c.FirstName, orderDirection);
        }

        public IEnumerable<Contact> GetClientsOrderByFirstNamePage(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return GetOrderedPage(DbContext.Contacts, c => c.FirstName, pageNumber, pageSize, orderDirection);
        }

        public IEnumerable<Contact> GetClientsOrderByLastName(OrderDirection orderDirection)
        {
            return GetOrdered(DbContext.Contacts, c => c.LastName, orderDirection);
        }

        public IEnumerable<Contact> GetClientsOrderByLastNamePage(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return GetOrderedPage(DbContext.Contacts, c => c.LastName, pageNumber, pageSize, orderDirection);
        }

        public IEnumerable<Contact> GetClientsOrderByBankAccountNumber(OrderDirection orderDirection)
        {
            return GetOrdered(DbContext.Contacts, c => c.BankAccountNumber, orderDirection);
        }

        public IEnumerable<Contact> GetClientsOrderByBankAccountNumberPage(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return GetOrderedPage(DbContext.Contacts, c => c.BankAccountNumber, pageNumber, pageSize, orderDirection);
        }

        public IEnumerable<Contact> FindByFullName(string firstName, string lastName)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                DbContext.Contacts
                    .Where(c =>
                        c.FirstName == firstName &&
                        c.LastName == lastName));
        }

        public IEnumerable<Contact> FindByFullName(string fullName)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                DbContext.Contacts
                    .Where(c =>
                        (c.FirstName + c.LastName) == fullName.Replace(" ", string.Empty)));
        }

        public IEnumerable<Contact> FindByFullNameLike(string fullNameSubstring)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                DbContext.Contacts
                    .Where(c =>
                        (c.FirstName + c.LastName).Contains(fullNameSubstring.Replace(" ", string.Empty))));
        }

        public IEnumerable<Contact> SearchContacts(string keyWord)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                DbContext.Contacts
                .Where(c=>c.FirstName.Contains(keyWord)
                    ||keyWord.Contains(c.FirstName)
                          || c.LastName.Contains(keyWord)
                          || keyWord.Contains(c.LastName)
                          || c.City.Name.Contains(keyWord)
                          || keyWord.Contains(c.City.Name)
                          || c.District.Name.Contains(keyWord)
                          || keyWord.Contains(c.District.Name)
                          || c.Street.Contains(keyWord)
                          || keyWord.Contains(c.Street)));
        }

        public IEnumerable<Contact> ExtendedSearchContacts(Contact contact)
        {
            throw new System.NotImplementedException();
        }
    }
}