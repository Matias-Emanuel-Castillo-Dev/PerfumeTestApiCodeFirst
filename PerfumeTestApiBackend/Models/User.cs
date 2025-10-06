using System.ComponentModel.DataAnnotations;

namespace PerfumeTestApiBackend.Models
{
    public class User : BaseModel
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100,ErrorMessage ="El email no puede exceder 100 carateres")]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
