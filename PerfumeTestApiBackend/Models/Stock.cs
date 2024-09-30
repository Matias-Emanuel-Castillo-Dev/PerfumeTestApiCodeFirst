using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfumeTestApiBackend.Models
{
    public class Stock
    {
        public int PerfumeID { get; set; }
        public int PerfumeryID { get; set; }
        public int Amount { get; set; }

        public Perfume Perfume { get; set; }
        public Perfumery Perfumery { get; set; }
    }
}
