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

        private IMapper<City, CityEntity> _cityToEntityMapper;
        private IMapper<CityEntity, City> _entityToCityMapper;
        private IMapper<District, DistrictEntity> _districtToEntityMapper;
        private IMapper<DistrictEntity, District> _entityToDistrictMapper;
        private IMapper<ContactCommunication, ContactCommunicationEntity> _contactCommunicationToEntityMapper;
        private IMapper<ContactCommunicationEntity, ContactCommunication> _entityToContactCommunicationMapper;
        private IMapper<Contract, ContractEntity> _contractToEntityMapper;
        private IMapper<ContractEntity, Contract> _entityToContractMapper;
        private IMapper<Contact, ContactEntity> _contactToEntityMapper;
        private IMapper<ContactEntity, Contact> _entityToContactMapper;
        private IMapper<Employee, EmployeeEntity> _employeeToEntityMapper;
        private IMapper<EmployeeEntity, Employee> _entityToEmployeeMapper;
        private IMapper<Offer, OfferEntity> _offerToEntityMapper;
        private IMapper<OfferEntity, Offer> _entityToOfferMapper;
        private IMapper<RealEstate, RealEstateEntity> _realEstateToEntityMapper;
        private IMapper<RealEstateEntity, RealEstate> _entityToRealEstateMapper;
        private IMapper<RealEstateType, RealEstateTypeEntity> _realEstateTypeToEntityMapper;
        private IMapper<RealEstateTypeEntity, RealEstateType> _entityToRealEstateTypeMapper;
        private IMapper<User, UserEntity> _userToEntityMapper;
        private IMapper<UserEntity, User> _entityToUserMapper;

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
            IMapper<City, CityEntity> cityToEntityMapper,
            IMapper<CityEntity, City> entityToCityMapper,
            IMapper<District, DistrictEntity> districtToEntityMapper,
            IMapper<DistrictEntity, District> entityToDistrictMapper,
            IMapper<ContactCommunication, ContactCommunicationEntity> contactCommunicationToEntityMapper,
            IMapper<ContactCommunicationEntity, ContactCommunication> entityToContactCommunicationMapper,
            IMapper<Contract, ContractEntity> contractToEntityMapper,
            IMapper<ContractEntity, Contract> entityToContractMapper,
            IMapper<Contact, ContactEntity> contactToEntityMapper,
            IMapper<ContactEntity, Contact> entityToContactMapper,
            IMapper<Employee, EmployeeEntity> employeeToEntityMapper,
            IMapper<EmployeeEntity, Employee> entityToEmployeeMapper,
            IMapper<Offer, OfferEntity> offerToEntityMapper,
            IMapper<OfferEntity, Offer> entityToOfferMapper,
            IMapper<RealEstate, RealEstateEntity> realEstateToEntityMapper,
            IMapper<RealEstateEntity, RealEstate> entityToRealEstateMapper,
            IMapper<RealEstateType, RealEstateTypeEntity> realEstateTypeToEntityMapper,
            IMapper<RealEstateTypeEntity, RealEstateType> entityToRealEstateTypeMapper,
            IMapper<User, UserEntity> userToEntityMapper,
            IMapper<UserEntity, User> entityToUserMapper)
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
