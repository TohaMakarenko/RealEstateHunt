using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Core;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public class DistrictMapper : IMapper<District, DistrictEntity>, IMapper<DistrictEntity, District>
    {
        IMapper<City, CityEntity> _cityToEntityMapper;
        IMapper<CityEntity, City> _entityToCityMapper;

        IMapper<Contact, ContactEntity> _contactToEntityMapper;
        IMapper<ContactEntity, Contact> _entityToContactMapper;

        IMapper<RealEstate, RealEstateEntity> _realEstateToEntityMapper;
        IMapper<RealEstateEntity, RealEstate> _entityToRealEstateMapper;

        public DistrictMapper(IMapper<City, CityEntity> cityToEntityMapper,
            IMapper<CityEntity, City> entityToCityMapper,
            IMapper<Contact, ContactEntity> contactToEntityMapper,
            IMapper<ContactEntity, Contact> entityToContactMapper,
            IMapper<RealEstate, RealEstateEntity> realEstateToEntityMapper,
            IMapper<RealEstateEntity, RealEstate> entityToRealEstateMapper)
        {
            _cityToEntityMapper = cityToEntityMapper;
            _entityToCityMapper = entityToCityMapper;
            _contactToEntityMapper = contactToEntityMapper;
            _entityToContactMapper = entityToContactMapper;
            _realEstateToEntityMapper = realEstateToEntityMapper;
            _entityToRealEstateMapper = entityToRealEstateMapper;
        }

        public DistrictEntity Map(District entity)
        {
            if (entity == null)
                return null;

            return new DistrictEntity() {
                Id = entity.Id,
                Name = entity.Name,
                CityId = entity.City.Id,
                City = _cityToEntityMapper.Map(entity.City),
                Contacts = _contactToEntityMapper.MapCollection(entity.Contacts),
                RealEstates = _realEstateToEntityMapper.MapCollection(entity.RealEstates)
            };
        }

        public District Map(DistrictEntity entity)
        {
            if (entity == null)
                return null;

            return new District() {
                Id = entity.Id,
                Name = entity.Name,
                City = _entityToCityMapper.Map(entity.City),
                Contacts = _entityToContactMapper.MapCollection(entity.Contacts),
                RealEstates = _entityToRealEstateMapper.MapCollection(entity.RealEstates)
            };
        }

        public IEnumerable<DistrictEntity> MapCollection(IEnumerable<District> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }

        public IEnumerable<District> MapCollection(IEnumerable<DistrictEntity> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }
    }
}
