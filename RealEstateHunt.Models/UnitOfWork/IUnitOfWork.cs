using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Models.Repositories;

namespace RealEstateHunt.Models.UnitOfWork
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
    }
}
