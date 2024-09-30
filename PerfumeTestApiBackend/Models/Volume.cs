using System.ComponentModel.DataAnnotations;

namespace PerfumeTestApiBackend.Models
{
    public class Volume : BaseModel
    {
        [Required]
        public int Quantity { get; set; }

        public ICollection<Perfume> Perfumes { get; set; }
    }
}
