using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.WebApp.Constants;
using RealEstateHunt.WebApp.Models;

namespace RealEstateHunt.WebApp.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IRealEstateService _realEstateService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public OfferController(IOfferService offerService, IRealEstateService realEstateService,
            IClientService clientService, IMapper mapper)
        {
            _offerService = offerService;
            _realEstateService = realEstateService;
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpPost]
        public Task<Offer> AddRecord([FromBody] Offer offer)
        {
            return _offerService.AddOfferAsync(offer);
        }

        public Task<Offer> Record(int id)
        {
            return _offerService.GetOfferAsync(id);
        }

        public Task<IEnumerable<Contact>> GetAvailableClients()
        {
            return _offerService.GetAvailableClientsAsync();
        }

        public async Task<IEnumerable<OfferGridModel>> GetPageAsync(int pageNumber)
        {
            return (await _offerService.GetOffersPageAsync(pageNumber, ViewConstants.DefaultPageSize))
                .Select(i => new OfferGridModel() {
                    Id = i.Id,
                    ContactId = i.Contact.Id,
                    ContactName = i.Contact.FirstName + " " + i.Contact.LastName,
                    RealEstateId = i.RealEstate.Id,
                    RealEstateName = i.RealEstate.Name,
                    
                });
        }

        public async Task<IEnumerable<RealEstate>> GetDesiredRealEstatesForClientAsync(int? contactId)
        {
            return contactId == null
                ? await _realEstateService.GetRealEstatesAsync()
                : await _offerService.GetDesiredRealEstatesForClientAsync(contactId.Value);
        }

        public async Task<IEnumerable<Contact>> GetContactsWhichDesireRealEstateAsync(int? realEstateid)
        {
            return realEstateid == null
                ? await _offerService.GetAvailableClientsAsync()
                : await _offerService.GetContactsWhichDesireRealEstateAsync(realEstateid.Value);
        }

        public Task DeclineOfferAsync(int offerId)
        {
            return _offerService.DeclineOfferAsync(offerId);
        }
    }
}