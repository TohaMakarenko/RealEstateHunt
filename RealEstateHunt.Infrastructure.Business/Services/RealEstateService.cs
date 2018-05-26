using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Enums;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.UnitOfWork;

namespace RealEstateHunt.Infrastructure.Business.Services
{
    public class RealEstateService : IRealEstateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RealEstateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddRealEstateAsync(RealEstate realEstate)
        {
            _unitOfWork.RealEstateRepository.Add(realEstate);
            return _unitOfWork.SaveAsync();
        }

        public Task RemoveRealEstateAsync(int id)
        {
            _unitOfWork.RealEstateRepository.Remove(id);
            return _unitOfWork.SaveAsync();
        }

        public Task RemoveRealEstateAsync(RealEstate realEstate)
        {
            _unitOfWork.RealEstateRepository.Remove(realEstate);
            return _unitOfWork.SaveAsync();
        }

        public Task EditRealEstateAsync(RealEstate realEstate)
        {
            _unitOfWork.RealEstateRepository.Update(realEstate);
            return _unitOfWork.SaveAsync();
        }

        public Task GetRealEstateAsync(int id)
        {
            return _unitOfWork.RealEstateRepository.FindByIdAsync(id);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesAsync()
        {
            return _unitOfWork.RealEstateRepository.GetEntitiesAsync();
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesPageAsync(int pageNumber, int pageSize)
        {
            return _unitOfWork.RealEstateRepository.GetPageAsync(pageNumber, pageSize);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesByTypeAsync(RealEstateType realEstateType)
        {
            return _unitOfWork.RealEstateRepository.GetRealEstatesByTypeAsync(realEstateType);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesByTypeAsync(int realEstateTypeId)
        {
            return _unitOfWork.RealEstateRepository.GetRealEstatesByTypeAsync(realEstateTypeId);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesByTypePageAsync(RealEstateType realEstateType,
            int pageNumber, int pageSize)
        {
            return _unitOfWork.RealEstateRepository.GetRealEstatesByTypePageAsync(realEstateType, pageNumber, pageSize);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesByTypePageAsync(int realEstateTypeId, int pageNumber,
            int pageSize)
        {
            return _unitOfWork.RealEstateRepository.GetRealEstatesByTypePageAsync(realEstateTypeId, pageNumber,
                pageSize);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPriceAsync(OrderDirection orderDirection)
        {
            return _unitOfWork.RealEstateRepository.GetRealEstatesOrderByPriceAsync(orderDirection);
        }

        public Task<IEnumerable<RealEstate>> GetRealEstatesOrderByPricePageAsync(int pageNumber, int pageSize,
            OrderDirection orderDirection)
        {
            return _unitOfWork.RealEstateRepository.GetRealEstatesOrderByPricePageAsync(pageNumber, pageSize,
                orderDirection);
        }
    }
}