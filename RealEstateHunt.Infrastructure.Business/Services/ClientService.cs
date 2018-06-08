using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Core.Data.UnitOfWork;

namespace RealEstateHunt.Infrastructure.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Contact> AddClientAsync(Contact contact)
        {
            var entity = await _unitOfWork.ContactRepository.AddAsync(contact);
            await _unitOfWork.SaveAsync();
            return entity;
        }

        public Task RemoveClientAsync(int id)
        {
            _unitOfWork.ContactRepository.Remove(id);
            return _unitOfWork.SaveAsync();
        }

        public Task RemoveClientAsync(Contact client)
        {
            _unitOfWork.ContactRepository.Remove(client);
            return _unitOfWork.SaveAsync();
        }

        public Task EditClient(Contact client)
        {
            _unitOfWork.ContactRepository.Update(client);
            return _unitOfWork.SaveAsync();
        }

        public Task<Contact> GetClientAsync(int id)
        {
            return _unitOfWork.ContactRepository.FindByIdAsync(id);
        }

        public Task<IEnumerable<Contact>> GetClientsAsync()
        {
            return _unitOfWork.ContactRepository.GetEntitiesAsync();
        }

        public Task<IEnumerable<Contact>> GetClientsPageAsync(int pageNumber, int pageSize)
        {
            return _unitOfWork.ContactRepository.GetPageAsync(pageNumber, pageSize);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByFirstNameAsync(OrderDirection orderDirection)
        {
            return _unitOfWork.ContactRepository.GetClientsOrderByFirstNameAsync(orderDirection);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByFirstNamePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return _unitOfWork.ContactRepository.GetClientsOrderByFirstNamePageAsync(pageNumber, pageSize,
                orderDirection);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByLastNameAsync(OrderDirection orderDirection)
        {
            return _unitOfWork.ContactRepository.GetClientsOrderByLastNameAsync(orderDirection);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByLastNamePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return _unitOfWork.ContactRepository.GetClientsOrderByLastNamePageAsync(pageNumber, pageSize,
                orderDirection);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByBankAccountNumberAsync(OrderDirection orderDirection)
        {
            return _unitOfWork.ContactRepository.GetClientsOrderByBankAccountNumberAsync(orderDirection);
        }

        public Task<IEnumerable<Contact>> GetClientsOrderByBankAccountNumberPageAsync(int pageNumber,
            int pageSize, OrderDirection orderDirection)
        {
            return _unitOfWork.ContactRepository.GetClientsOrderByBankAccountNumberPageAsync(pageNumber, pageSize,
                orderDirection);
        }
    }
}