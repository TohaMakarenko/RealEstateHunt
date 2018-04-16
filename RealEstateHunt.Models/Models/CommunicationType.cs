using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    public class CommunicationType
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
    }
}
