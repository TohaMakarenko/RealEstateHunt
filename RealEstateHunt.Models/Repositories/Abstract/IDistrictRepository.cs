using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Models.Repositories
{
    interface IDistrictRepository : IRepository<District>
    {
        District FindByName(string name);
    }
}
