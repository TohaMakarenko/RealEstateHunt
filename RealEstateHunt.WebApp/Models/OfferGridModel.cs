namespace RealEstateHunt.WebApp.Models
{
    public class OfferGridModel
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int RealEstateId { get; set; }
        public string RealEstateName { get; set; }
    }
}