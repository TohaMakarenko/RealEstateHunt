using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.UnitOfWork;

namespace RealEstateHunt.Infrastructure.Business.Services
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Contact>> SearchContactsAsync(string keyWord)
        {
            return _unitOfWork.ContactRepository.SearchContactsAsync(keyWord);
        }

        public Task<IEnumerable<RealEstate>> SearchRealEstatesAsync(string keyWord)
        {
            return _unitOfWork.RealEstateRepository.SearchRealEstatesAsync(keyWord);
        }

        public async Task<(IEnumerable<RealEstate> realEstates, IEnumerable<Contact> contacts)> SearchAllAsync(
            string keyWord)
        {
            (IEnumerable<RealEstate> realEstates, IEnumerable<Contact> contacts) result;
            result.realEstates = await SearchRealEstatesAsync(keyWord);
            result.contacts = await SearchContactsAsync(keyWord);
            return result;
        }

        public Task<IEnumerable<Contact>> ExtendedSearchContactsAsync(Contact contact)
        {
            return _unitOfWork.ContactRepository.ExtendedSearchContactsAsync(contact);
        }
    }
}