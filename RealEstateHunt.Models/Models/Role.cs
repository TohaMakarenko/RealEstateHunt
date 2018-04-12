using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    class Role
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public int Name { get; set; }
    }
}
