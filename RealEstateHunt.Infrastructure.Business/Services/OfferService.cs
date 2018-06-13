using System;
using System.Collections.Generic;
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

        private const int MaxOffersPerUser = 5;

        public OfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Offer> AddOfferAsync(Offer offer)
        {
            if (await _unitOfWork.OfferRepository.GetCanAddOfferToClientAsync(offer.Contact.Id, MaxOffersPerUser)) {
                return await _unitOfWork.OfferRepository.AddAsync(offer);
            }

            return null;
        }

        public Task<Offer> GetOfferAsync(int id)
        {
            return _unitOfWork.OfferRepository.FindByIdAsync(id);
        }

        public Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return _unitOfWork.OfferRepository.GetEntitiesAsync();
        }

        public Task<IEnumerable<Offer>> GetOffersPageAsync(int pageNumber, int pageSize)
        {
            return _unitOfWork.OfferRepository.GetPageAsync(pageNumber, pageSize);
        }

        public Task<IEnumerable<Contact>> GetAvailableClientsAsync()
        {
            return _unitOfWork.ContactRepository.GetAvailableForOfferClients(MaxOffersPerUser);
        }

        public Task<IEnumerable<RealEstate>> GetDesiredRealEstatesForClientAsync(int contactId)
        {
            return _unitOfWork.RealEstateRepository.GetDesiredRealEstatesForClientAsync(contactId);
        }

        public Task<IEnumerable<Contact>> GetContactsWhichDesireRealEstateAsync(int realEstateid)
        {
            return _unitOfWork.ContactRepository.GetContactsWhichDesireRealEstateAsync(realEstateid, MaxOffersPerUser);
        }

        public async Task DeclineOfferAsync(int offerId)
        {
            var offer = await _unitOfWork.OfferRepository.FindByIdAsync(offerId);
            if (offer == null) throw new ArgumentNullException(nameof(offer));

            offer.IsDeclined = true;
            _unitOfWork.OfferRepository.Update(offer);
            await _unitOfWork.SaveAsync();
        }
    }
}