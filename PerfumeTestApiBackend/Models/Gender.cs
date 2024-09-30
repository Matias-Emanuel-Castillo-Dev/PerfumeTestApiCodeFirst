using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfumeTestApiBackend.Models
{
    public class Gender : BaseModel
    {
        [Required]
        [StringLength(20)]
        public string TypeGender { get; set; }

        public ICollection<Perfume> Perfumes { get; set; }

    }
}
