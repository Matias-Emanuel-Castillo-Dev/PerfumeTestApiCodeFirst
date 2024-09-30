using System.ComponentModel.DataAnnotations;

namespace PerfumeTestApiBackend.Models
{
    public class Brand : BaseModel
    {
        [Required]
        public string Name { get; set; }

        public int PerfumeID { get; set; }
        public Perfume Perfume { get; set; }
    }
}
