using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Business.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<IEnumerable<District>> GetDistrictsAsync();
        Task<IEnumerable<District>> GetDistrictsByCityAsync(int cityId);
    }
}