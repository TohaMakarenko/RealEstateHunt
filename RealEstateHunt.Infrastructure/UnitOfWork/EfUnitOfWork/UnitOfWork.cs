using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Infrastructure.Repositories;
using RealEstateHunt.Infrastructure.Repositories.EfRepositories;

namespace RealEstateHunt.Infrastructure.UnitOfWork.EfUnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly RehDbContext _dbContext;

        private ICityRepository _cityRepository;
        private IContactCommunicationRepository _contactCommunicationRepository;
        private IContactRepository _contactRepository;
        private IContractRepository _contractRepository;
        private IDistrictRepository _districtRepository;
        private IEmployeeRepository _employeeRepository;
        private IOfferRepository _offerRepository;
        private IRealEstateRepository _realEstateRepository;
        private IRealEstateTypeRepository _realEstateTypeRepository;
        private IUserRepository _userRepository;

        public ICityRepository CityRepository =>
            _cityRepository ?? (_cityRepository = new CityRepository(_dbContext));

        public IContactCommunicationRepository ContactCommunicationRepository =>
            _contactCommunicationRepository ?? (_contactCommunicationRepository = new ContactCommunicationRepository(_dbContext));

        public IContactRepository ContactRepository =>
            _contactRepository ?? (_contactRepository = new ContactRepository(_dbContext));

        public IContractRepository ContractRepository =>
            _contractRepository ?? (_contractRepository = new ContractRepository(_dbContext));

        public IDistrictRepository DistrictRepository =>
            _districtRepository ?? (_districtRepository = new DistrictRepository(_dbContext));

        public IEmployeeRepository EmployeeRepository =>
            _employeeRepository ?? (_employeeRepository = new EmployeeRepository(_dbContext));

        public IOfferRepository OfferRepository =>
            _offerRepository ?? (_offerRepository = new OfferRepository(_dbContext));

        public IRealEstateRepository RealEstateRepository =>
            _realEstateRepository ?? (_realEstateRepository = new RealEstateRepository(_dbContext));

        public IRealEstateTypeRepository RealEstateTypeRepository =>
            _realEstateTypeRepository ?? (_realEstateTypeRepository = new RealEstateTypeRepository(_dbContext));

        public IUserRepository UserRepository =>
            _userRepository ?? (_userRepository = new UserRepository(_dbContext));

        public UnitOfWork(RehDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
