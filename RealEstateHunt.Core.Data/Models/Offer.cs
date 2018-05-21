using System.Collections.Generic;

namespace RealEstateHunt.Core.Data
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RealEstate RealEstate { get; set; }
        public Employee Manager { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public IEnumerable<Contract> Contracts { get; set; }
    }
}
