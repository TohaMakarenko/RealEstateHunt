using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Core;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Mappers
{
    class RealEstateTypeMapper : IMapper<RealEstateType, RealEstateTypeEntity>, IMapper<RealEstateTypeEntity, RealEstateType>
    {
        public RealEstateTypeEntity Map(RealEstateType entity)
        {
            return new RealEstateTypeEntity() {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public RealEstateType Map(RealEstateTypeEntity entity)
        {
            return new RealEstateType() {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public IEnumerable<RealEstateTypeEntity> MapCollection(IEnumerable<RealEstateType> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }

        public IEnumerable<RealEstateType> MapCollection(IEnumerable<RealEstateTypeEntity> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }
    }
}
