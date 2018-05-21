namespace RealEstateHunt.Core.Data
{
    public class ContactCommunication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Contact Contact { get; set; }
    }
}
