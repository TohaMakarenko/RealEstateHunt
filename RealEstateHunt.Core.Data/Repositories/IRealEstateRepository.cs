using System.Collections.Generic;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IRealEstateRepository : IRepository<RealEstate>
    {
        IEnumerable<RealEstate> FindByCityName(string cityName);
        IEnumerable<RealEstate> FindByCityAndDistrictName(string cityName, string districtName);
    }
}
