using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealEstateHunt.Infrastructure.Repositories;
using RealEstateHunt.Infrastructure.Repositories.EfRepositories;
using RealEstateHunt.Infrastructure.Mappers;
using RealEstateHunt.Core;

namespace RealEstateHunt.Infrastructure.UnitOfWork.EfUnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly RehDbContext _dbContext;

        private ICollectionMapper<City, CityEntity> _cityToEntityMapper;
        private ICollectionMapper<CityEntity, City> _entityToCityMapper;
        private ICollectionMapper<District, DistrictEntity> _districtToEntityMapper;
        private ICollectionMapper<DistrictEntity, District> _entityToDistrictMapper;
        private ICollectionMapper<ContactCommunication, ContactCommunicationEntity> _contactCommunicationToEntityMapper;
        private ICollectionMapper<ContactCommunicationEntity, ContactCommunication> _entityToContactCommunicationMapper;
        private ICollectionMapper<Contract, ContractEntity> _contractToEntityMapper;
        private ICollectionMapper<ContractEntity, Contract> _entityToContractMapper;
        private ICollectionMapper<Contact, ContactEntity> _contactToEntityMapper;
        private ICollectionMapper<ContactEntity, Contact> _entityToContactMapper;
        private ICollectionMapper<Employee, EmployeeEntity> _employeeToEntityMapper;
        private ICollectionMapper<EmployeeEntity, Employee> _entityToEmployeeMapper;
        private ICollectionMapper<Offer, OfferEntity> _offerToEntityMapper;
        private ICollectionMapper<OfferEntity, Offer> _entityToOfferMapper;
        private ICollectionMapper<RealEstate, RealEstateEntity> _realEstateToEntityMapper;
        private ICollectionMapper<RealEstateEntity, RealEstate> _entityToRealEstateMapper;
        private ICollectionMapper<RealEstateType, RealEstateTypeEntity> _realEstateTypeToEntityMapper;
        private ICollectionMapper<RealEstateTypeEntity, RealEstateType> _entityToRealEstateTypeMapper;
        private ICollectionMapper<User, UserEntity> _userToEntityMapper;
        private ICollectionMapper<UserEntity, User> _entityToUserMapper;

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

        public UnitOfWork(RehDbContext dbContext,
            ICollectionMapper<City, CityEntity> cityToEntityMapper,
            ICollectionMapper<CityEntity, City> entityToCityMapper,
            ICollectionMapper<District, DistrictEntity> districtToEntityMapper,
            ICollectionMapper<DistrictEntity, District> entityToDistrictMapper,
            ICollectionMapper<ContactCommunication, ContactCommunicationEntity> contactCommunicationToEntityMapper,
            ICollectionMapper<ContactCommunicationEntity, ContactCommunication> entityToContactCommunicationMapper,
            ICollectionMapper<Contract, ContractEntity> contractToEntityMapper,
            ICollectionMapper<ContractEntity, Contract> entityToContractMapper,
            ICollectionMapper<Contact, ContactEntity> contactToEntityMapper,
            ICollectionMapper<ContactEntity, Contact> entityToContactMapper,
            ICollectionMapper<Employee, EmployeeEntity> employeeToEntityMapper,
            ICollectionMapper<EmployeeEntity, Employee> entityToEmployeeMapper,
            ICollectionMapper<Offer, OfferEntity> offerToEntityMapper,
            ICollectionMapper<OfferEntity, Offer> entityToOfferMapper,
            ICollectionMapper<RealEstate, RealEstateEntity> realEstateToEntityMapper,
            ICollectionMapper<RealEstateEntity, RealEstate> entityToRealEstateMapper,
            ICollectionMapper<RealEstateType, RealEstateTypeEntity> realEstateTypeToEntityMapper,
            ICollectionMapper<RealEstateTypeEntity, RealEstateType> entityToRealEstateTypeMapper,
            ICollectionMapper<User, UserEntity> userToEntityMapper,
            ICollectionMapper<UserEntity, User> entityToUserMapper)
        {
            _dbContext = dbContext;
            _cityToEntityMapper = cityToEntityMapper;
            _entityToCityMapper = entityToCityMapper;
            _districtToEntityMapper = districtToEntityMapper;
            _entityToDistrictMapper = entityToDistrictMapper;
            _contactCommunicationToEntityMapper = contactCommunicationToEntityMapper;
            _entityToContactCommunicationMapper = entityToContactCommunicationMapper;
            _contractToEntityMapper = contractToEntityMapper;
            _entityToContractMapper = entityToContractMapper;
            _contactToEntityMapper = contactToEntityMapper;
            _entityToContactMapper = entityToContactMapper;
            _employeeToEntityMapper = employeeToEntityMapper;
            _entityToEmployeeMapper = entityToEmployeeMapper;
            _offerToEntityMapper = offerToEntityMapper;
            _entityToOfferMapper = entityToOfferMapper;
            _realEstateToEntityMapper = realEstateToEntityMapper;
            _entityToRealEstateMapper = entityToRealEstateMapper;
            _realEstateTypeToEntityMapper = realEstateTypeToEntityMapper;
            _entityToRealEstateTypeMapper = entityToRealEstateTypeMapper;
            _userToEntityMapper = userToEntityMapper;
            _entityToUserMapper = entityToUserMapper;
        }

        public ICityRepository CityRepository =>
            _cityRepository ?? (_cityRepository = new CityRepository(_dbContext, _cityToEntityMapper, _entityToCityMapper));

        public IContactCommunicationRepository ContactCommunicationRepository =>
            _contactCommunicationRepository ?? (_contactCommunicationRepository
            = new ContactCommunicationRepository(_dbContext, _contactCommunicationToEntityMapper, _entityToContactCommunicationMapper));

        public IContactRepository ContactRepository =>
            _contactRepository ?? (_contactRepository
            = new ContactRepository(_dbContext, _contactToEntityMapper, _entityToContactMapper));

        public IContractRepository ContractRepository =>
            _contractRepository ?? (_contractRepository
            = new ContractRepository(_dbContext, _contractToEntityMapper, _entityToContractMapper));

        public IDistrictRepository DistrictRepository =>
            _districtRepository ?? (_districtRepository
            = new DistrictRepository(_dbContext, _districtToEntityMapper, _entityToDistrictMapper));

        public IEmployeeRepository EmployeeRepository =>
            _employeeRepository ?? (_employeeRepository
            = new EmployeeRepository(_dbContext, _employeeToEntityMapper, _entityToEmployeeMapper));

        public IOfferRepository OfferRepository =>
            _offerRepository ?? (_offerRepository
            = new OfferRepository(_dbContext, _offerToEntityMapper, _entityToOfferMapper));

        public IRealEstateRepository RealEstateRepository =>
            _realEstateRepository ?? (_realEstateRepository
            = new RealEstateRepository(_dbContext, _realEstateToEntityMapper, _entityToRealEstateMapper));

        public IRealEstateTypeRepository RealEstateTypeRepository =>
            _realEstateTypeRepository ?? (_realEstateTypeRepository
            = new RealEstateTypeRepository(_dbContext, _realEstateTypeToEntityMapper, _entityToRealEstateTypeMapper));

        public IUserRepository UserRepository =>
            _userRepository ?? (_userRepository
            = new UserRepository(_dbContext, _userToEntityMapper, _entityToUserMapper));



        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
