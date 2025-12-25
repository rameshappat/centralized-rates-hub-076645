namespace CentralizedRatesHub.Models
{
    public class RateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; } // e.g., Tiered, Promotional
        public string Status { get; set; } // e.g., Active, Inactive
    }
}