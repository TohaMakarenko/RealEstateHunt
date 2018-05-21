using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Core;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public class ContractMapper : IMapper<Contract, ContractEntity>, IMapper<ContractEntity, Contract>
    {
        IMapper<Offer, OfferEntity> _offerToEntityMapper;
        IMapper<OfferEntity, Offer> _entityToOfferMapper;

        IMapper<Contact, ContactEntity> _contactToEntityMapper;
        IMapper<ContactEntity, Contact> _entityToContactMapper;

        IMapper<Employee, EmployeeEntity> _employeeToEntityMapper;
        IMapper<EmployeeEntity, Employee> _entityToEmployeeMapper;

        public ContractMapper(IMapper<Offer, OfferEntity> offerToEntityMapper,
            IMapper<OfferEntity, Offer> entityToOfferMapper,
            IMapper<Contact, ContactEntity> contactToEntityMapper,
            IMapper<ContactEntity, Contact> entityToContactMapper,
            IMapper<Employee, EmployeeEntity> employeeToEntityMapper,
            IMapper<EmployeeEntity, Employee> entityToEmployeeMapper)
        {
            _offerToEntityMapper = offerToEntityMapper;
            _entityToOfferMapper = entityToOfferMapper;
            _contactToEntityMapper = contactToEntityMapper;
            _entityToContactMapper = entityToContactMapper;
            _employeeToEntityMapper = employeeToEntityMapper;
            _entityToEmployeeMapper = entityToEmployeeMapper;
        }

        public ContractEntity Map(Contract entity)
        {
            if (entity == null)
                return null;

            return new ContractEntity() {
                Id = entity.Id,
                Name = entity.Name,
                OfferId = entity.Offer.Id,
                Offer = _offerToEntityMapper.Map(entity.Offer),
                ClientId = entity.Client.Id,
                Client = _contactToEntityMapper.Map(entity.Client),
                ManagerId = entity.Manager.Id,
                Manager = _employeeToEntityMapper.Map(entity.Manager),
                Description = entity.Description
            };
        }

        public Contract Map(ContractEntity entity)
        {
            if (entity == null)
                return null;

            return new Contract() {
                Id = entity.Id,
                Name = entity.Name,
                Offer = _entityToOfferMapper.Map(entity.Offer),
                Client = _entityToContactMapper.Map(entity.Client),
                Manager = _entityToEmployeeMapper.Map(entity.Manager),
                Description = entity.Description
            };
        }

        public IEnumerable<ContractEntity> MapCollection(IEnumerable<Contract> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }

        public IEnumerable<Contract> MapCollection(IEnumerable<ContractEntity> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }
    }
}
