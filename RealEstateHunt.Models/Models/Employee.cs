using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }

        public Job Job { get; set; }
    }
}
