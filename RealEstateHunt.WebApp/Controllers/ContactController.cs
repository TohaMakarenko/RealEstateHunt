using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.WebApp.Constants;

namespace RealEstateHunt.WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IClientService _clientService;

        public ContactController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public Task<Contact> Record(int id)
        {
            return _clientService.GetClientAsync(id);
        }

        public async void DeleteRecord(int id)
        {
            await _clientService.RemoveClientAsync(id);
        }

        public Task<Contact> AddRecord(Contact contact)
        {
            return _clientService.AddClientAsync(contact);
        }

        public Task UpdateContact(Contact contact)
        {
            return _clientService.EditClient(contact);
        }

        public Task<IEnumerable<Contact>> GetPage(int page)
        {
            return _clientService.GetClientsPageAsync(page, ViewConstants.DefaultPageSize);
        }

        public Task<IEnumerable<Contact>> GetOrderByFirstNamePage(int page, int orderDirection)
        {
            if (orderDirection != 0 && orderDirection != 1)
                throw new ArgumentException("order direction must be 0 or 1", nameof(orderDirection));
            return _clientService.GetClientsOrderByFirstNamePageAsync(page, ViewConstants.DefaultPageSize,
                (OrderDirection) orderDirection);
        }

        public Task<IEnumerable<Contact>> GetOrderByLasttNamePage(int page, int orderDirection)
        {
            if (orderDirection != 0 && orderDirection != 1)
                throw new ArgumentException("order direction must be 0 or 1", nameof(orderDirection));
            return _clientService.GetClientsOrderByLastNamePageAsync(page, ViewConstants.DefaultPageSize,
                (OrderDirection) orderDirection);
        }

        public Task<IEnumerable<Contact>> GetOrderByBankAccountNumberPage(int page, int orderDirection)
        {
            if (orderDirection != 0 && orderDirection != 1)
                throw new ArgumentException("order direction must be 0 or 1", nameof(orderDirection));
            return _clientService.GetClientsOrderByBankAccountNumberPageAsync(page, ViewConstants.DefaultPageSize,
                (OrderDirection) orderDirection);
        }
    }
}