using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Models.Repositories
{
    interface IRealEstateRepository : IRepository<RealEstate>
    {
        IEnumerable<RealEstate> FindByCityName(string cityName);
        IEnumerable<RealEstate> FindByCityAndDistrictName(string cityName, string districtName);
    }
}
