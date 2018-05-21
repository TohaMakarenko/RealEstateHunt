using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Core;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public class CityMapper : IMapper<City, CityEntity>, IMapper<CityEntity, City>
    {
        IMapper<District, DistrictEntity> _districtToEntityMapper;
        IMapper<DistrictEntity, District> _entityToDistrictMapper;

        IMapper<Contact, ContactEntity> _contactToEntityMapper;
        IMapper<ContactEntity, Contact> _entityToContactMapper;

        IMapper<RealEstate, RealEstateEntity> _realEstateToEntityMapper;
        IMapper<RealEstateEntity, RealEstate> _entityToRealEstateMapper;

        public CityMapper(IMapper<District, DistrictEntity> districtToEntityMapper,
            IMapper<DistrictEntity, District> entityToDistrictMapper,
            IMapper<Contact, ContactEntity> contactToEntityMapper,
            IMapper<ContactEntity, Contact> entityToContactMapper,
            IMapper<RealEstate, RealEstateEntity> realEstateToEntityMapper,
            IMapper<RealEstateEntity, RealEstate> entityToRealEstateMapper)
        {
            _districtToEntityMapper = districtToEntityMapper;
            _entityToDistrictMapper = entityToDistrictMapper;
            _contactToEntityMapper = contactToEntityMapper;
            _entityToContactMapper = entityToContactMapper;
            _realEstateToEntityMapper = realEstateToEntityMapper;
            _entityToRealEstateMapper = entityToRealEstateMapper;
        }

        public City Map(CityEntity entity)
        {
            if (entity == null)
                return null;

            return new City() {
                Id = entity.Id,
                Name = entity.Name,
                Contacts = _entityToContactMapper.MapCollection(entity.Contacts),
                Districts = _entityToDistrictMapper.MapCollection(entity.Districts),
                RealEstates = _entityToRealEstateMapper.MapCollection(entity.RealEstates)
            };
        }

        public CityEntity Map(City entity)
        {
            if (entity == null)
                return null;

            return new CityEntity() {
                Id = entity.Id,
                Name = entity.Name,
                Contacts = _contactToEntityMapper.MapCollection(entity.Contacts),
                Districts = _districtToEntityMapper.MapCollection(entity.Districts),
                RealEstates = _realEstateToEntityMapper.MapCollection(entity.RealEstates)
            };
        }

        public IEnumerable<CityEntity> MapCollection(IEnumerable<City> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }

        public IEnumerable<City> MapCollection(IEnumerable<CityEntity> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }
    }
}
