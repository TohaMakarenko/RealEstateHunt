
namespace RealEstateHunt.Core.Data.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Offer Offer { get; set; }
        public Contact Client { get; set; }
        public Employee Manager { get; set; }
        public string Description { get; set; }
    }
}
