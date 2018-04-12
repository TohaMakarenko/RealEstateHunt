using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    class City
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
    }
}
