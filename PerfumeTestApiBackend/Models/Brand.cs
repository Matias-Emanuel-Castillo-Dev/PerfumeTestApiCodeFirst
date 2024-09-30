using System.ComponentModel.DataAnnotations;

namespace PerfumeTestApiBackend.Models
{
    public class Brand : BaseModel
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Perfume> Perfumes { get; set; }


    }
}
