﻿using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        public ContactRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<IEnumerable<Contact>> GetEntitiesAsync()
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                await DbContext.Contacts.ToListAsync());
        }

        public override async Task<IEnumerable<Contact>> GetPageAsync(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                await DbContext.Contacts
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByFirstNameAsync(OrderDirection orderDirection)
        {
            return GetOrderedAsync(DbContext.Contacts, c => c.FirstName, orderDirection);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByFirstNamePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return GetOrderedPageAsync(DbContext.Contacts, c => c.FirstName, pageNumber, pageSize, orderDirection);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByLastNameAsync(OrderDirection orderDirection)
        {
            return GetOrderedAsync(DbContext.Contacts, c => c.LastName, orderDirection);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByLastNamePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return GetOrderedPageAsync(DbContext.Contacts, c => c.LastName, pageNumber, pageSize, orderDirection);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByBankAccountNumberAsync(OrderDirection orderDirection)
        {
            return GetOrderedAsync(DbContext.Contacts, c => c.BankAccountNumber, orderDirection);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByBankAccountNumberPageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return GetOrderedPageAsync(DbContext.Contacts, c => c.BankAccountNumber, pageNumber, pageSize,
                orderDirection);
        }

        public async Task<IEnumerable<Contact>> FindByFullNameAsync(string firstName, string lastName)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                await DbContext.Contacts
                    .Where(c =>
                        c.FirstName == firstName &&
                        c.LastName == lastName)
                    .ToListAsync());
        }

        public async Task<IEnumerable<Contact>> FindByFullNameAsync(string fullName)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                await DbContext.Contacts
                    .Where(c =>
                        (c.FirstName + c.LastName) == fullName.Replace(" ", string.Empty))
                    .ToListAsync());
        }

        public async Task<IEnumerable<Contact>> FindByFullNameLikeAsync(string fullNameSubstring)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                await DbContext.Contacts
                    .Where(c =>
                        (c.FirstName + c.LastName)
                        .Contains(fullNameSubstring.Replace(" ", string.Empty)))
                    .ToListAsync());
        }

        public async Task<IEnumerable<Contact>> SearchContactsAsync(string keyWord)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                await DbContext.Contacts
                    .Where(c => c.FirstName.Contains(keyWord)
                                || keyWord.Contains(c.FirstName)
                                || c.LastName.Contains(keyWord)
                                || keyWord.Contains(c.LastName)
                                || c.City.Name.Contains(keyWord)
                                || keyWord.Contains(c.City.Name)
                                || c.District.Name.Contains(keyWord)
                                || keyWord.Contains(c.District.Name)
                                || c.Street.Contains(keyWord)
                                || keyWord.Contains(c.Street))
                    .ToListAsync());
        }

        public async Task<IEnumerable<Contact>> ExtendedSearchContactsAsync(Contact contact)
        {
            return mapper.Map<IEnumerable<ContactEntity>, IEnumerable<Contact>>(
                await DbContext.Contacts
                    .Where(c => contact.Id != 0 && c.Id == contact.Id
                                || !string.IsNullOrEmpty(contact.FirstName) && c.FirstName.Contains(contact.FirstName)
                                || !string.IsNullOrEmpty(contact.LastName) && c.LastName.Contains(contact.LastName)
                                || contact.City != null && contact.City.Id < c.CityId
                                || contact.District != null && contact.District.Id < c.DistrictId
                                || !string.IsNullOrEmpty(contact.Street) && c.Street.Contains(contact.Street)
                                || contact.PreferredPrice != 0 && contact.PreferredPrice < c.PreferredPrice
                                || contact.PreferredType != null && contact.PreferredType.Id == c.PreferredTypeId)
                    .ToListAsync());
        }
    }
}