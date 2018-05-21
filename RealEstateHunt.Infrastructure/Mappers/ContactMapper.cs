using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Core;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public class ContactMapper : IMapper<Contact, ContactEntity>, IMapper<ContactEntity, Contact>
    {
        IMapper<City, CityEntity> _cityToEntityMapper;
        IMapper<CityEntity, City> _entityToCityMapper;

        IMapper<District, DistrictEntity> _districtToEntityMapper;
        IMapper<DistrictEntity, District> _entityToDistrictMapper;

        IMapper<ContactCommunication, ContactCommunicationEntity> _contactCommunicationToEntityMapper;
        IMapper<ContactCommunicationEntity, ContactCommunication> _entityToContactCommunicationMapper;

        IMapper<Contract, ContractEntity> _contractToEntityMapper;
        IMapper<ContractEntity, Contract> _entityToContractMapper;

        public ContactMapper(IMapper<City, CityEntity> cityToEntityMapper,
            IMapper<CityEntity, City> entityToCityMapper,
            IMapper<District, DistrictEntity> districtToEntityMapper,
            IMapper<DistrictEntity, District> entityToDistrictMapper,
            IMapper<ContactCommunication, ContactCommunicationEntity> contactCommunicationToEntityMapper,
            IMapper<ContactCommunicationEntity, ContactCommunication> entityToContactCommunicationMapper,
            IMapper<Contract, ContractEntity> contractToEntityMapper,
            IMapper<ContractEntity, Contract> entityToContractMapper)
        {
            _cityToEntityMapper = cityToEntityMapper;
            _entityToCityMapper = entityToCityMapper;
            _districtToEntityMapper = districtToEntityMapper;
            _entityToDistrictMapper = entityToDistrictMapper;
            _contactCommunicationToEntityMapper = contactCommunicationToEntityMapper;
            _entityToContactCommunicationMapper = entityToContactCommunicationMapper;
            _contractToEntityMapper = contractToEntityMapper;
            _entityToContractMapper = entityToContractMapper;
        }

        public ContactEntity Map(Contact entity)
        {
            if (entity == null)
                return null;

            return new ContactEntity() {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                City = _cityToEntityMapper.Map(entity.City),
                CityId = entity.City.Id,
                District = _districtToEntityMapper.Map(entity.District),
                DistrictId = entity.District.Id,
                BankAccountNumber = entity.BankAccountNumber,
                BirthDate = entity.BirthDate,
                Number = entity.Number,
                Street = entity.Street,
                ContactCommunications = _contactCommunicationToEntityMapper.MapCollection(entity.ContactCommunications),
                Contracts = _contractToEntityMapper.MapCollection(entity.Contracts)
            };
        }

        public Contact Map(ContactEntity entity)
        {
            if (entity == null)
                return null;

            return new Contact() {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                City = _entityToCityMapper.Map(entity.City),
                District = _entityToDistrictMapper.Map(entity.District),
                BankAccountNumber = entity.BankAccountNumber,
                BirthDate = entity.BirthDate,
                Number = entity.Number,
                Street = entity.Street,
                ContactCommunications = _entityToContactCommunicationMapper.MapCollection(entity.ContactCommunications),
                Contracts = _entityToContractMapper.MapCollection(entity.Contracts)
            };
        }

        public IEnumerable<ContactEntity> MapCollection(IEnumerable<Contact> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }

        public IEnumerable<Contact> MapCollection(IEnumerable<ContactEntity> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }
    }
}
