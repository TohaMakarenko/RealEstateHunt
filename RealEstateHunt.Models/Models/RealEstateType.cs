using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    public class RealEstateType
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public int Name { get; set; }
    }
}
