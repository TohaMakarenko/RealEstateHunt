using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Business.Services
{
    public interface IRealEstateService
    {
        Task<RealEstate> AddRealEstateAsync(RealEstate realEstate);
        Task RemoveRealEstateAsync(int id);
        Task RemoveRealEstateAsync(RealEstate realEstate);
        Task EditRealEstateAsync(RealEstate realEstate);
        Task<RealEstate> GetRealEstateAsync(int id);
        Task<IEnumerable<RealEstate>> GetRealEstatesAsync();
        Task<IEnumerable<RealEstate>> GetRealEstatesPageAsync(int pageNumber, int pageSize);
        Task<IEnumerable<RealEstate>> GetRealEstatesByTypeAsync(RealEstateType realEstateType);
        Task<IEnumerable<RealEstate>> GetRealEstatesByTypeAsync(int realEstateTypeId);

        Task<IEnumerable<RealEstate>> GetRealEstatesByTypePageAsync(RealEstateType realEstateType, int pageNumber,
            int pageSize);

        Task<IEnumerable<RealEstate>> GetRealEstatesByTypePageAsync(int realEstateTypeId, int pageNumber, int pageSize);

        Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPriceAsync(OrderDirection orderDirection);

        Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPricePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection);
    }
}