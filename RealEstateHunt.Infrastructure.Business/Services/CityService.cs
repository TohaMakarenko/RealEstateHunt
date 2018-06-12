using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.UnitOfWork;

namespace RealEstateHunt.Infrastructure.Business.Services
{
    public class CityService :ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public Task<IEnumerable<City>> GetCitiesAsync()
        {
            return _unitOfWork.CityRepository.GetEntitiesAsync();
        }

        public Task<IEnumerable<District>> GetDistrictsAsync()
        {
            return _unitOfWork.DistrictRepository.GetEntitiesAsync();
        }

        public Task<IEnumerable<District>> GetDistrictsByCityAsync(int cityId)
        {
            return _unitOfWork.DistrictRepository.GetByCityAsync(cityId);
        }
    }
}