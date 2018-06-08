using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateHunt.Core.Business.Models;
using RealEstateHunt.Core.Business.Services;

namespace RealEstateHunt.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        
        public Task<SearchResult> Search(string searchKey)
        {
            return _searchService.SearchAllAsync(searchKey);
        }
    }
}