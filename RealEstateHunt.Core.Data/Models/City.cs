using System.Collections.Generic;

namespace RealEstateHunt.Core.Data
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<District> Districts { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<RealEstate> RealEstates { get; set; }
    }
}
