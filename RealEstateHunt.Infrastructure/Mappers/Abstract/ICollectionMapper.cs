using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public interface ICollectionMapper<TIn, TOut> : IMapper<TIn, TOut>
    {
        IEnumerable<TOut> MapCollection(IEnumerable<TIn> entities);
    }
}
