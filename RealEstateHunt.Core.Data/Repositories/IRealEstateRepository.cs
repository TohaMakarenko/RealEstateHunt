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
        Task<IEnumerable<RealEstate>> GetRealEstatesByTypeAsync(int realEstateTypeId);

        Task<IEnumerable<RealEstate>> GetRealEstatesByTypePageAsync(RealEstateType realEstateType, int pageNumber,
            int pageSize);

        Task<IEnumerable<RealEstate>> GetRealEstatesByTypePageAsync(int realEstateTypeId, int pageNumber, int pageSize);

        Task<IEnumerable<RealEstate>> GetRealEstatesOrderByTypeAsync(OrderDirection orderDirection);

        Task<IEnumerable<RealEstate>> GetRealEstatesOrderByTypePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection);

        Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPriceAsync(OrderDirection orderDirection);

        Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPricePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection);

        Task<IEnumerable<RealEstate>> SearchRealEstatesAsync(string keyWord);

        Task<IEnumerable<RealEstate>> GetDesiredRealEstatesForClientAsync(int clientId);
    }
}