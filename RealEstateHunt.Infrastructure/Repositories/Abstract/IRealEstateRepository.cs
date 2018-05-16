using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Infrastructure.Repositories
{
    public interface IRealEstateRepository : IRepository<RealEstateEntity>
    {
        IEnumerable<RealEstateEntity> FindByCityName(string cityName);
        IEnumerable<RealEstateEntity> FindByCityAndDistrictName(string cityName, string districtName);
    }
}
