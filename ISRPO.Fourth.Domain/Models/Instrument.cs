namespace ISRPO.Fourth.Domain.Models
{
    public class Instrument : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string Image { get; set; }
    }
}