using System.Threading.Tasks;
using RealEstateHunt.Core.Data.Repositories;

namespace RealEstateHunt.Core.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        IContactRepository ContactRepository { get; }
        IDistrictRepository DistrictRepository { get; }
        IOfferRepository OfferRepository { get; }
        IRealEstateRepository RealEstateRepository { get; }
        IRealEstateTypeRepository RealEstateTypeRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
