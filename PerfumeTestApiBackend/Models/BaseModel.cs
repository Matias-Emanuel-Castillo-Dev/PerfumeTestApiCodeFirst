using System.ComponentModel.DataAnnotations;

namespace PerfumeTestApiBackend.Models
{
    public class BaseModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
