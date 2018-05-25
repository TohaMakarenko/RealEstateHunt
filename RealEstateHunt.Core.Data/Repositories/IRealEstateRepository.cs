using System.Collections.Generic;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IRealEstateRepository : IRepository<RealEstate>
    {
        IEnumerable<RealEstate> FindByCityName(string cityName);
        IEnumerable<RealEstate> FindByCityAndDistrictName(string cityName, string districtName);

        IEnumerable<RealEstate> GetRealEstatesByType(RealEstateType realEstateType);
        IEnumerable<RealEstate> GetRealEstatesByTypePage(RealEstateType realEstateType, int pageNumber, int pageSize);
        IEnumerable<RealEstate> GetRealEstatesOrderByPrice(OrderDirection orderDirection);

        IEnumerable<RealEstate> GetRealEstatesOrderByPricePage(int pageNumber, int pageSize,
            OrderDirection orderDirection);

        IEnumerable<RealEstate> SearchRealEstates(string keyWord);
    }
}