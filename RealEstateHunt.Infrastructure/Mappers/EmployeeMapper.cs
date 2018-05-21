using RealEstateHunt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public class EmployeeMapper : IMapper<Employee, EmployeeEntity>, IMapper<EmployeeEntity, Employee>
    {
        IMapper<Contact, ContactEntity> _contactToEntityMapper;
        IMapper<ContactEntity, Contact> _entityToContactMapper;

        IMapper<Contract, ContractEntity> _contractToEntityMapper;
        IMapper<ContractEntity, Contract> _entityToContractMapper;

        public EmployeeMapper(IMapper<Contact, ContactEntity> contactToEntityMapper,
            IMapper<ContactEntity, Contact> entityToContactMapper,
            IMapper<Contract, ContractEntity> contractToEntityMapper,
            IMapper<ContractEntity, Contract> entityToContractMapper)
        {
            _contactToEntityMapper = contactToEntityMapper;
            _entityToContactMapper = entityToContactMapper;
            _contractToEntityMapper = contractToEntityMapper;
            _entityToContractMapper = entityToContractMapper;
        }

        public EmployeeEntity Map(Employee entity)
        {
            if (entity == null)
                return null;

            return new EmployeeEntity() {
                Id = entity.Id,
                ContactId = entity.Contact.Id,
                Contact = _contactToEntityMapper.Map(entity.Contact),
                Contracts = _contractToEntityMapper.MapCollection(entity.Contracts)
            };
        }

        public Employee Map(EmployeeEntity entity)
        {
            if (entity == null)
                return null;

            return new Employee() {
                Id = entity.Id,
                Contact = _entityToContactMapper.Map(entity.Contact),
                Contracts = _entityToContractMapper.MapCollection(entity.Contracts)
            };
        }

        public IEnumerable<EmployeeEntity> MapCollection(IEnumerable<Employee> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }

        public IEnumerable<Employee> MapCollection(IEnumerable<EmployeeEntity> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }
    }
}
