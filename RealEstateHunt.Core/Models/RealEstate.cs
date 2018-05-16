using System.Collections.Generic;

namespace RealEstateHunt.Core
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RealEstateType Type { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public int Square { get; set; }
        public string Description { get; set; }

        public IEnumerable<Offer> Offers { get; set; }
    }
}
