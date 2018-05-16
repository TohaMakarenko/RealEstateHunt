using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public interface IMapper <Tin, TOut>
    {
        TOut Map(Tin entity);
    }
}
