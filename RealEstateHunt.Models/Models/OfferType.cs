using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    public class OfferType
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
    }
}
