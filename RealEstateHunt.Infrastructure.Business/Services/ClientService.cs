using System.Collections.Generic;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;

namespace RealEstateHunt.Infrastructure.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IContactRepository _contactRepository;

        public ClientService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void AddClient(Contact contact)
        {
            _contactRepository.Add(contact);
        }

        public void RemoveClient(int id)
        {
            _contactRepository.Remove(id);
        }

        public void RemoveClient(Contact client)
        {
            _contactRepository.Remove(client);
        }

        public void EditClient(Contact client)
        {
            _contactRepository.Update(client);
        }

        public Contact GetClient(int id)
        {
            return _contactRepository.FindById(id);
        }

        public IEnumerable<Contact> GetClients()
        {
            return _contactRepository.GetEntities();
        }

        public IEnumerable<Contact> GetClientsPage(int pageNumber, int pageSize)
        {
            return _contactRepository.GetPage(pageNumber, pageSize);
        }

        public IEnumerable<Contact> GetClientsOrderByFirstName(OrderDirection orderDirection)
        {
            return _contactRepository.GetClientsOrderByFirstName(orderDirection);
        }

        public IEnumerable<Contact> GetClientsOrderByFirstNamePage(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return _contactRepository.GetClientsOrderByFirstNamePage(pageNumber, pageSize, orderDirection);
        }

        public IEnumerable<Contact> GetClientsOrderByLastName(OrderDirection orderDirection)
        {
            return _contactRepository.GetClientsOrderByLastName(orderDirection);
        }

        public IEnumerable<Contact> GetClientsOrderByLastNamePage(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return _contactRepository.GetClientsOrderByLastNamePage(pageNumber, pageSize, orderDirection);
        }

        public IEnumerable<Contact> GetClientsOrderByBankAccountNumber(OrderDirection orderDirection)
        {
            return _contactRepository.GetClientsOrderByBankAccountNumber(orderDirection);
        }

        public IEnumerable<Contact> GetClientsOrderByBankAccountNumberPage(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return _contactRepository.GetClientsOrderByBankAccountNumberPage(pageNumber, pageSize, orderDirection);
        }
    }
}