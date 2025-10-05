namespace PerfumeTestApiBackend.Models.DTOs
{
    public class PerfumeCreateDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int Gender { get; set; }
        public int Brand { get; set; }
        public int Volume { get; set; }
        public List<StockCreateDTO> Stocks { get; set; } // Lista de Stocks
    }
}