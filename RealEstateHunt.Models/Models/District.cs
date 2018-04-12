using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    class District
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public City City { get; set; }
    }
}
