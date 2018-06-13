using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.WebApp.Constants;
using RealEstateHunt.WebApp.Models;

namespace RealEstateHunt.WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public ContactController(IClientService clientService, ISearchService searchService, IMapper mapper)
        {
            _clientService = clientService;
            _searchService = searchService;
            _mapper = mapper;
        }

        public Task<Contact> Record(int id)
        {
            return _clientService.GetClientAsync(id);
        }

        [HttpDelete]
        public Task DeleteRecord(int id)
        {
            return _clientService.RemoveClientAsync(id);
        }

        [HttpPost]
        public Task<Contact> AddRecord([FromBody] Contact contact)
        {
            return _clientService.AddClientAsync(contact);
        }

        [HttpPost]
        public Task UpdateRecord([FromBody] Contact contact)
        {
            return _clientService.EditClient(contact);
        }

        public async Task<IEnumerable<ContactGridModel>> GetPage(int page)
        {
            return _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactGridModel>>(
                await _clientService.GetClientsPageAsync(page, ViewConstants.DefaultPageSize));
        }

        public async Task<IEnumerable<ContactGridModel>> GetOrderByFirstNamePage(int page, int orderDirection)
        {
            if (orderDirection != 0 && orderDirection != 1)
                throw new ArgumentException("order direction must be 0 or 1", nameof(orderDirection));
            return _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactGridModel>>(
                await _clientService.GetClientsOrderByFirstNamePageAsync(page, ViewConstants.DefaultPageSize,
                    (OrderDirection) orderDirection));
        }

        public async Task<IEnumerable<ContactGridModel>> GetOrderByLasttNamePage(int page, int orderDirection)
        {
            if (orderDirection != 0 && orderDirection != 1)
                throw new ArgumentException("order direction must be 0 or 1", nameof(orderDirection));
            return _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactGridModel>>(
                await _clientService.GetClientsOrderByLastNamePageAsync(page, ViewConstants.DefaultPageSize,
                    (OrderDirection) orderDirection));
        }

        public async Task<IEnumerable<ContactGridModel>> GetOrderByBankAccountNumberPage(int page, int orderDirection)
        {
            if (orderDirection != 0 && orderDirection != 1)
                throw new ArgumentException("order direction must be 0 or 1", nameof(orderDirection));
            return _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactGridModel>>(
                await _clientService.GetClientsOrderByBankAccountNumberPageAsync(page, ViewConstants.DefaultPageSize,
                    (OrderDirection) orderDirection));
        }

        public async Task<IEnumerable<ContactGridModel>> Search(string keyWord)
        {
            return _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactGridModel>>(
                await _searchService.SearchContactsAsync(keyWord));
        }
    }
}