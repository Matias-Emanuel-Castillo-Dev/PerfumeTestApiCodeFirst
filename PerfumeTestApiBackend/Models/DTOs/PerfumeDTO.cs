namespace PerfumeTestApiBackend.Models.DTOs
{
    public class PerfumeDTO : BaseModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Brand { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public ICollection<PerfumeryDTO> Stock { get; set; }
    }
}
