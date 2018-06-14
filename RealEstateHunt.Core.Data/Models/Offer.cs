using System.Collections.Generic;

namespace RealEstateHunt.Core.Data.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RealEstate RealEstate { get; set; }
        public Contact Contact { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsDeclined { get; set; }
    }
}
