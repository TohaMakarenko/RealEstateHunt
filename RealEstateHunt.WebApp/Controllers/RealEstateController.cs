using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.WebApp.Constants;
using Contact = Microsoft.Azure.KeyVault.Models.Contact;

namespace RealEstateHunt.WebApp.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly IRealEstateService _realEstateService;

        public RealEstateController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public Task<RealEstate> Record(int id)
        {
            return _realEstateService.GetRealEstateAsync(id);
        }

        [HttpDelete]
        public async void DeleteRecord(int id)
        {
            await _realEstateService.RemoveRealEstateAsync(id);
        }

        [HttpPost]
        public Task<RealEstate> AddRecord([FromBody] RealEstate realEstate)
        {
            return _realEstateService.AddRealEstateAsync(realEstate);
        }

        [HttpPost]
        public Task UpdateRecord([FromBody] RealEstate realEstate)
        {
            return _realEstateService.EditRealEstateAsync(realEstate);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstates()
        {
            return _realEstateService.GetRealEstatesAsync();
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesPage(int pageNumber)
        {
            return _realEstateService.GetRealEstatesPageAsync(pageNumber, ViewConstants.DefaultPageSize);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesByType(int realEstateTypeId)
        {
            return _realEstateService.GetRealEstatesByTypeAsync(realEstateTypeId);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesByTypePage(int realEstateTypeId, int pageNumber)
        {
            return _realEstateService.GetRealEstatesByTypePageAsync(realEstateTypeId, pageNumber,
                ViewConstants.DefaultPageSize);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPrice(int orderDirection)
        {
            if (orderDirection != 0 && orderDirection != 1)
                throw new ArgumentException("order direction must be 0 or 1", nameof(orderDirection));

            return _realEstateService.GetRealEstatesOrderByPriceAsync((OrderDirection) orderDirection);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPricePage(int pageNumber, int orderDirection)
        {
            if (orderDirection != 0 && orderDirection != 1)
                throw new ArgumentException("order direction must be 0 or 1", nameof(orderDirection));

            return _realEstateService.GetRealEstatesOrderByPricePageAsync(pageNumber, ViewConstants.DefaultPageSize,
                (OrderDirection) orderDirection);
        }

        public Task<IEnumerable<RealEstateType>> GetRealEstateTypes()
        {
            return _realEstateService.GetRealEstateTypesAsync();
        }
    }
}