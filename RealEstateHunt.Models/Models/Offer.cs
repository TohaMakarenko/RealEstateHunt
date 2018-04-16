using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    public class Offer
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        [ForeignKey("RealEstate")]
        public int RealEstateId { get; set; }

        public RealEstate RealEstate { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }

        public OfferType Type { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public Employee Manager { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        public int Price { get; set; }
    }
}
