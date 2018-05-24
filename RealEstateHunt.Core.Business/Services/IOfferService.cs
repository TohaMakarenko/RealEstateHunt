using RealEstateHunt.Core.Data;

namespace RealEstateHunt.Core.Business.Services
{
    public interface IOfferService
    {
        bool AddOfferToClient(Contact client, Offer offer);
        bool IsDesired(Contact client, RealEstate realEstate);
        void DeclineOffer(Offer offer);
    }
}