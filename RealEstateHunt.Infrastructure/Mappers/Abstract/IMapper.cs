using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public interface IMapper<TIn, TOut>
    {
        TOut Map(TIn entity);
        IEnumerable<TOut> MapCollection(IEnumerable<TIn> entities);
    }
}
