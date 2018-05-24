using System.Collections.Generic;
using RealEstateHunt.Core.Data;
using RealEstateHunt.Core.Data.Enums;

namespace RealEstateHunt.Core.Business.Services
{
    public interface IRealEstateService
    {
        void AddRealEstate(RealEstate realEstate);
        void RemoveRealEstate(int id);
        void RemoveRealEstate(RealEstate realEstate);
        void EditRealEstate(RealEstate realEstate);
        void GetRealEstate(RealEstate realEstate);
        IEnumerable<RealEstate> GetRealEstates();
        IEnumerable<RealEstate> GetRealEstatesPage(int pageNumber, int pageSize);
        IEnumerable<RealEstate> GetRealEstatesByType(RealEstateType realEstateType);
        IEnumerable<RealEstate> GetRealEstatesByTypePage(RealEstateType realEstateType, int pageNumber, int pageSize);
        IEnumerable<RealEstate> GetRealEstatesOrderByPrice(OrderDirection orderDirection);
        IEnumerable<RealEstate> GetRealEstatesOrderByPricePage(int pageNumber, int pageSize,
            OrderDirection orderDirection);
    }
}