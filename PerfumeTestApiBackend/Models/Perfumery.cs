using System.ComponentModel.DataAnnotations;

namespace PerfumeTestApiBackend.Models
{
    public class Perfumery : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
