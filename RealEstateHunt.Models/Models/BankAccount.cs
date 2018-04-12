using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    class BankAccount
    {
        public int Id { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Number { get; set; }
    }
}
