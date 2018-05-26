using System;
using System.Linq;
using System.Threading.Tasks;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Core.Data.UnitOfWork;

namespace RealEstateHunt.Infrastructure.Business.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;

        //TODO: make it as db constant
        private const int MaxOffersPerUser = 5;

        public OfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> AddOfferToClientAsync(Contact client, Offer offer)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (offer == null)
                throw new ArgumentNullException(nameof(offer));

            return AddOfferToClientAsync(client.Id, offer);
        }

        public async Task<bool> AddOfferToClientAsync(int clientId, Offer offer)
        {
            if (offer == null)
                throw new ArgumentNullException(nameof(offer));

            if ((await _unitOfWork.ContactRepository.FindByIdAsync(clientId)).Offers.Count() > MaxOffersPerUser) {
                return false;
            }

            offer.Contact = new Contact() {
                Id = clientId
            };
            _unitOfWork.OfferRepository.Add(offer);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public Task<bool> IsDesiredAsync(Contact client, RealEstate realEstate)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (realEstate == null)
                throw new ArgumentNullException(nameof(realEstate));

            return IsDesiredAsync(client.Id, realEstate);
        }

        public async Task<bool> IsDesiredAsync(int clientId, RealEstate realEstate)
        {
            if (realEstate == null)
                throw new ArgumentNullException(nameof(realEstate));

            var client = await _unitOfWork.ContactRepository.FindByIdAsync(clientId);
            return client.PreferredPrice > realEstate.Price
                   && client.PreferredType.Id == realEstate.Type.Id;
        }

        public Task DeclineOfferAsync(Offer offer)
        {
            if (offer == null) throw new ArgumentNullException(nameof(offer));

            offer.IsDeclined = true;
            _unitOfWork.OfferRepository.Update(offer);
            return _unitOfWork.SaveAsync();
        }
    }
}