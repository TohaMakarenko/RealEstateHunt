using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Business.Services
{
    public interface IOfferService
    {
        Task<Offer> AddOfferAsync(Offer offer);
        Task<Offer> GetOfferAsync(int id);
        Task<IEnumerable<Offer>> GetOffersAsync();
        Task<IEnumerable<Offer>> GetOffersPageAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Contact>> GetAvailableClientsAsync();
        Task<IEnumerable<RealEstate>> GetDesiredRealEstatesForClientAsync(int contactId);
        Task<IEnumerable<Contact>> GetContactsWhichDesireRealEstateAsync(int realEstateid);
        Task DeclineOfferAsync(int offerId);
    }
}