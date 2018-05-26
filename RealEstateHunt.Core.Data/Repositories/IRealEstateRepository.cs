using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IRealEstateRepository : IRepository<RealEstate>
    {
        Task<IEnumerable<RealEstate>> FindByCityNameAsync(string cityName);
        Task<IEnumerable<RealEstate>> FindByCityAndDistrictNameAsync(string cityName, string districtName);

        Task<IEnumerable<RealEstate>> GetRealEstatesByTypeAsync(RealEstateType realEstateType);
        Task<IEnumerable<RealEstate>> GetRealEstatesByTypePageAsync(RealEstateType realEstateType, int pageNumber, int pageSize);
        Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPriceAsync(OrderDirection orderDirection);

        Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPricePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection);

        Task<IEnumerable<RealEstate>> SearchRealEstatesAsync(string keyWord);
    }
}