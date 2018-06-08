using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.WebApp.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public Task<IEnumerable<City>> GetCities()
        {
            return _cityService.GetCitiesAsync();
        }

        public Task<IEnumerable<District>> GetDistricts()
        {
            return _cityService.GetDistrictsAsync();
        }
    }
}