using System.ComponentModel.DataAnnotations;

namespace PerfumeTestApiBackend.Models
{
    public class Volume : BaseModel
    {
        [Required]
        public int Quantity { get; set; }

        public int PerfumeID { get; set; }
        public Perfume Perfume { get; set; }
    }
}
