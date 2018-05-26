using System.Threading.Tasks;
using RealEstateHunt.Core.Data;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Business.Services
{
    public interface IOfferService
    {
        Task<bool> AddOfferToClientAsync(Contact client, Offer offer);
        Task<bool> AddOfferToClientAsync(int clientId, Offer offer);
        Task<bool> IsDesiredAsync(Contact client, RealEstate realEstate);
        Task<bool> IsDesiredAsync(int clientId, RealEstate realEstate);
        Task DeclineOfferAsync(Offer offer);
    }
}