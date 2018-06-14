using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure.Data.Entities
{
    [Table("Offer")]
    public class OfferEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        [ForeignKey("RealEstate")]
        public int RealEstateId { get; set; }

        public RealEstateEntity RealEstate { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        
        public ContactEntity Contact { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        public int Price { get; set; }
        
        public bool IsDeclined { get; set; }
    }
}
