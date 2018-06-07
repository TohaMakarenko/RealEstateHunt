using System.Collections.Generic;
using RealEstateHunt.Core.Data.Models;

namespace RealEstateHunt.Core.Business.Models
{
    public class SearchResult
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<RealEstate> RealEstates { get; set; }
    }
}