using System.Collections.Generic;

namespace RealEstateHunt.Core.Data
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<RealEstate> RealEstates { get; set; }
    }
}
