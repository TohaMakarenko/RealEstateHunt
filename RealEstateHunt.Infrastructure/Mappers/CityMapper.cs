using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Core;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public class CityMapper : ICollectionMapper<City, CityEntity>, ICollectionMapper<CityEntity, City>
    {
        ICollectionMapper<District, DistrictEntity> _districtToEntityMapper;
        ICollectionMapper<DistrictEntity, District> _entityToDistrictMapper;

        ICollectionMapper<Contact, ContactEntity> _contactToEntityMapper;
        ICollectionMapper<ContactEntity, Contact> _entityToContactMapper;

        ICollectionMapper<RealEstate, RealEstateEntity> _realEstateToEntityMapper;
        ICollectionMapper<RealEstateEntity, RealEstate> _entityToRealEstateMapper;

        public CityMapper(ICollectionMapper<District, DistrictEntity> districtToEntityMapper,
            ICollectionMapper<DistrictEntity, District> entityToDistrictMapper,
            ICollectionMapper<Contact, ContactEntity> contactToEntityMapper,
            ICollectionMapper<ContactEntity, Contact> entityToContactMapper,
            ICollectionMapper<RealEstate, RealEstateEntity> realEstateToEntityMapper,
            ICollectionMapper<RealEstateEntity, RealEstate> entityToRealEstateMapper)
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
