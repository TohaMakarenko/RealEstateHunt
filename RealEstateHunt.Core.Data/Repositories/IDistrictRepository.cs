using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        Task<IEnumerable<District>> FindByNameAsync(string name);
        Task<IEnumerable<District>> GetByCityAsync(int cityId);
    }
}
