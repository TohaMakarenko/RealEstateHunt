using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Core;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public class OfferMapper : IMapper<Offer, OfferEntity>, IMapper<OfferEntity, Offer>
    {
        IMapper<Employee, EmployeeEntity> _employeeToEntityMapper;
        IMapper<EmployeeEntity, Employee> _entityToEmployeeMapper;

        IMapper<RealEstate, RealEstateEntity> _realEstateToEntityMapper;
        IMapper<RealEstateEntity, RealEstate> _entityToRealEstateMapper;

        IMapper<Contract, ContractEntity> _contractToEntityMapper;
        IMapper<ContractEntity, Contract> _entityToContractMapper;

        public OfferMapper(IMapper<Employee, EmployeeEntity> employeeToEntityMapper,
            IMapper<EmployeeEntity, Employee> entityToEmployeeMapper,
            IMapper<RealEstate, RealEstateEntity> realEstateToEntityMapper,
            IMapper<RealEstateEntity, RealEstate> entityToRealEstateMapper,
            IMapper<Contract, ContractEntity> contractToEntityMapper,
            IMapper<ContractEntity, Contract> entityToContractMapper)
        {
            _employeeToEntityMapper = employeeToEntityMapper;
            _entityToEmployeeMapper = entityToEmployeeMapper;
            _realEstateToEntityMapper = realEstateToEntityMapper;
            _entityToRealEstateMapper = entityToRealEstateMapper;
            _contractToEntityMapper = contractToEntityMapper;
            _entityToContractMapper = entityToContractMapper;
        }

        public OfferEntity Map(Offer entity)
        {
            if (entity == null)
                return null;

            return new OfferEntity() {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ManagerId = entity.Manager.Id,
                Manager = _employeeToEntityMapper.Map(entity.Manager),
                RealEstateId = entity.RealEstate.Id,
                RealEstate = _realEstateToEntityMapper.Map(entity.RealEstate),
                Contracts = _contractToEntityMapper.MapCollection(entity.Contracts)
            };
        }

        public Offer Map(OfferEntity entity)
        {
            if (entity == null)
                return null;

            return new Offer() {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                Manager = _entityToEmployeeMapper.Map(entity.Manager),
                RealEstate = _entityToRealEstateMapper.Map(entity.RealEstate),
                Contracts = _entityToContractMapper.MapCollection(entity.Contracts)
            };
        }

        public IEnumerable<OfferEntity> MapCollection(IEnumerable<Offer> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }

        public IEnumerable<Offer> MapCollection(IEnumerable<OfferEntity> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }
    }
}
