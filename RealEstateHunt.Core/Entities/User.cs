
namespace RealEstateHunt.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
