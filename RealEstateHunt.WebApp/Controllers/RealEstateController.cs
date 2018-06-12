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
using Contact = Microsoft.Azure.KeyVault.Models.Contact;

namespace RealEstateHunt.WebApp.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly IRealEstateService _realEstateService;
        private readonly IMapper _mapper;

        public RealEstateController(IRealEstateService realEstateService, IMapper mapper)
        {
            _realEstateService = realEstateService;
            _mapper = mapper;
        }

        public Task<RealEstate> Record(int id)
        {
            return _realEstateService.GetRealEstateAsync(id);
        }

        [HttpDelete]
        public Task DeleteRecord(int id)
        {
            return _realEstateService.RemoveRealEstateAsync(id);
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

        public async Task<IEnumerable<RealEstateGridModel>> GetRealEstatesPage(int pageNumber)
        {
            return _mapper.Map<IEnumerable<RealEstate>, IEnumerable<RealEstateGridModel>>(
                await _realEstateService.GetRealEstatesPageAsync(pageNumber, ViewConstants.DefaultPageSize));
        }

        public async Task<IEnumerable<RealEstateGridModel>> GetRealEstatesByTypePage(int realEstateTypeId,
            int pageNumber)
        {
            return _mapper.Map<IEnumerable<RealEstate>, IEnumerable<RealEstateGridModel>>(
                await _realEstateService.GetRealEstatesByTypePageAsync(realEstateTypeId, pageNumber,
                    ViewConstants.DefaultPageSize));
        }

        public async Task<IEnumerable<RealEstateGridModel>> GetRealEstatesOrderByPricePage(int pageNumber,
            int orderDirection)
        {
            if (orderDirection != 0 && orderDirection != 1)
                throw new ArgumentException("order direction must be 0 or 1", nameof(orderDirection));

            return _mapper.Map<IEnumerable<RealEstate>, IEnumerable<RealEstateGridModel>>(
                await _realEstateService.GetRealEstatesOrderByPricePageAsync(pageNumber, ViewConstants.DefaultPageSize,
                    (OrderDirection) orderDirection));
        }

        public async Task<IEnumerable<RealEstateGridModel>> GetRealEstatesOrderByTypePage(int pageNumber,
            int orderDirection)
        {
            if (orderDirection != 0 && orderDirection != 1)
                throw new ArgumentException("order direction must be 0 or 1", nameof(orderDirection));

            return _mapper.Map<IEnumerable<RealEstate>, IEnumerable<RealEstateGridModel>>(
                await _realEstateService.GetRealEstatesOrderByTypePageAsync(pageNumber, ViewConstants.DefaultPageSize,
                    (OrderDirection) orderDirection));
        }


        public Task<IEnumerable<RealEstateType>> GetRealEstateTypes()
        {
            return _realEstateService.GetRealEstateTypesAsync();
        }
    }
}