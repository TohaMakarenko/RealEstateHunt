using System.Threading.Tasks;
using RealEstateHunt.Core.Repositories;

namespace RealEstateHunt.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        IContactCommunicationRepository ContactCommunicationRepository { get; }
        IContactRepository ContactRepository { get; }
        IContractRepository ContractRepository { get; }
        IDistrictRepository DistrictRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IOfferRepository OfferRepository { get; }
        IRealEstateRepository RealEstateRepository { get; }
        IRealEstateTypeRepository RealEstateTypeRepository { get; }
        IUserRepository UserRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
