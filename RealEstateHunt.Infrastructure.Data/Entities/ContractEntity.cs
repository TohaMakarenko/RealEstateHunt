using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure.Data.Entities
{
    [Table("Contract")]
    public class ContractEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [ForeignKey("Offer")]
        public int? OfferId { get; set; }

        public OfferEntity Offer { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public ContactEntity Client { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public EmployeeEntity Manager { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }
    }
}
