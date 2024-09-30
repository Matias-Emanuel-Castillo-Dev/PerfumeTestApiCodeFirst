using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PerfumeTestApiBackend.Models
{
    public class Perfume : BaseModel
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Precision(precision:9,scale:2)]
        public decimal Price { get; set; }

        public ICollection<Volume> Volumes { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Gender> Genders { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}
