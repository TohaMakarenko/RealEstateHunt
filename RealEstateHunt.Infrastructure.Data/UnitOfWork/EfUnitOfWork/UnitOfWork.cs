using System;
using System.Threading.Tasks;
using RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories;
using AutoMapper;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Core.Data.UnitOfWork;

namespace RealEstateHunt.Infrastructure.Data.UnitOfWork.EfUnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly RehDbContext _dbContext;

        private IMapper _mapper;

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

        public UnitOfWork(RehDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ICityRepository CityRepository =>
            _cityRepository ?? (_cityRepository = new CityRepository(_dbContext, _mapper));

        public IContactCommunicationRepository ContactCommunicationRepository =>
            _contactCommunicationRepository ?? (_contactCommunicationRepository
            = new ContactCommunicationRepository(_dbContext, _mapper));

        public IContactRepository ContactRepository =>
            _contactRepository ?? (_contactRepository
            = new ContactRepository(_dbContext, _mapper));

        public IContractRepository ContractRepository =>
            _contractRepository ?? (_contractRepository
            = new ContractRepository(_dbContext, _mapper));

        public IDistrictRepository DistrictRepository =>
            _districtRepository ?? (_districtRepository
            = new DistrictRepository(_dbContext, _mapper));

        public IEmployeeRepository EmployeeRepository =>
            _employeeRepository ?? (_employeeRepository
            = new EmployeeRepository(_dbContext, _mapper));

        public IOfferRepository OfferRepository =>
            _offerRepository ?? (_offerRepository
            = new OfferRepository(_dbContext, _mapper));

        public IRealEstateRepository RealEstateRepository =>
            _realEstateRepository ?? (_realEstateRepository
            = new RealEstateRepository(_dbContext, _mapper));

        public IRealEstateTypeRepository RealEstateTypeRepository =>
            _realEstateTypeRepository ?? (_realEstateTypeRepository
            = new RealEstateTypeRepository(_dbContext, _mapper));

        public IUserRepository UserRepository =>
            _userRepository ?? (_userRepository
            = new UserRepository(_dbContext, _mapper));

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
