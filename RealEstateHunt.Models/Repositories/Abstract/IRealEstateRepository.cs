using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Models.Repositories
{
    public interface IRealEstateRepository : IRepository<RealEstate>
    {
        IEnumerable<RealEstate> FindByCityName(string cityName);
        IEnumerable<RealEstate> FindByCityAndDistrictName(string cityName, string districtName);
    }
}
