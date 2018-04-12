using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    class User
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }


        [Column(TypeName = "varchar(256)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Phone { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
