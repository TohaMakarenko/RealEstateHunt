using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Core;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public class RealEstateMapper : ICollectionMapper<RealEstate, RealEstateEntity>, ICollectionMapper<RealEstateEntity, RealEstate>
    {
        IMapper<RealEstateType, RealEstateTypeEntity> _realEstateTypeToEntityMapper;
        IMapper<RealEstateTypeEntity, RealEstateType> _entityToRealEstateTypeMapper;

        IMapper<City, CityEntity> _cityToEntityMapper;
        IMapper<CityEntity, City> _entityToCityMapper;

        IMapper<District, DistrictEntity> _districtToEntityMapper;
        IMapper<DistrictEntity, District> _entityToDistrictMapper;

        ICollectionMapper<Offer, OfferEntity> _offerToEntityMapper;
        ICollectionMapper<OfferEntity, Offer> _entityToOfferMapper;

        public RealEstateMapper(IMapper<RealEstateType, RealEstateTypeEntity> realEstateTypeToEntityMapper,
            IMapper<RealEstateTypeEntity, RealEstateType> entityToRealEstateTypeMapper,
            IMapper<City, CityEntity> cityToEntityMapper,
            IMapper<CityEntity, City> entityToCityMapper,
            IMapper<District, DistrictEntity> districtToEntityMapper,
            IMapper<DistrictEntity, District> entityToDistrictMapper,
            ICollectionMapper<Offer, OfferEntity> offerToEntityMapper,
            ICollectionMapper<OfferEntity, Offer> entityToOfferMapper)
        {
            _realEstateTypeToEntityMapper = realEstateTypeToEntityMapper;
            _entityToRealEstateTypeMapper = entityToRealEstateTypeMapper;
            _cityToEntityMapper = cityToEntityMapper;
            _entityToCityMapper = entityToCityMapper;
            _districtToEntityMapper = districtToEntityMapper;
            _entityToDistrictMapper = entityToDistrictMapper;
            _offerToEntityMapper = offerToEntityMapper;
            _entityToOfferMapper = entityToOfferMapper;
        }

        public RealEstateEntity Map(RealEstate entity)
        {
            return new RealEstateEntity() {
                Id = entity.Id,
                Name = entity.Name,
                TypeId = entity.Type.Id,
                Type = _realEstateTypeToEntityMapper.Map(entity.Type),
                CityId = entity.City.Id,
                City = _cityToEntityMapper.Map(entity.City),
                DistrictId = entity.District.Id,
                District = _districtToEntityMapper.Map(entity.District),
                Street = entity.Street,
                Number = entity.Number,
                Floor = entity.Floor,
                Square = entity.Square,
                Description = entity.Description,
                Offers = _offerToEntityMapper.MapCollection(entity.Offers)
            };
        }

        public RealEstate Map(RealEstateEntity entity)
        {
            return new RealEstate() {
                Id = entity.Id,
                Name = entity.Name,
                Type = _entityToRealEstateTypeMapper.Map(entity.Type),
                City = _entityToCityMapper.Map(entity.City),
                District = _entityToDistrictMapper.Map(entity.District),
                Street = entity.Street,
                Number = entity.Number,
                Floor = entity.Floor,
                Square = entity.Square,
                Description = entity.Description,
                Offers = _entityToOfferMapper.MapCollection(entity.Offers)
            };
        }

        public IEnumerable<RealEstateEntity> MapCollection(IEnumerable<RealEstate> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }

        public IEnumerable<RealEstate> MapCollection(IEnumerable<RealEstateEntity> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }
    }
}
