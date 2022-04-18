namespace ISRPO.Fourth.DTO
{
    public class InstrumentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string Image { get; set; }
        
        public InstrumentDTO() { }
    }
}