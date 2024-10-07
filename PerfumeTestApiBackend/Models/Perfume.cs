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
        public bool Available { get; set; }


        public int GenderID { get; set; }
        public int BrandID { get; set; }
        public int VolumeID { get; set; }


        public Volume Volume { get; set; }
        public Brand Brand { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Stock> Stocks { get; set; }  
    }
}
