using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    class Contract
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [ForeignKey("Offer")]
        public int OfferId { get; set; }

        public Offer Offer { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public Contact Client { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public Employee Manager { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }
    }
}
