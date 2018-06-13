using System.Threading.Tasks;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Data.Repositories
{
    public interface IOfferRepository : IRepository<Offer>
    {
        Task<bool> GetCanAddOfferToClientAsync(int clientId, int maxOffers);
    }
}
