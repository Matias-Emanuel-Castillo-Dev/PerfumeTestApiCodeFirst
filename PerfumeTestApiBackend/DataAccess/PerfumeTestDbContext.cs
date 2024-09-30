using Microsoft.EntityFrameworkCore;
using PerfumeTestApiBackend.Models;

namespace PerfumeTestApiBackend.DataAccess
{
    public class PerfumeTestDbContext : DbContext
    {
        public PerfumeTestDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //CON ESTO DECLARAMOS LA RELACION MUCHOS <- A -> MUCHOS DE PERFUME <--STOCK--> PEFUMERY
            modelBuilder.Entity<Stock>().HasKey( prop => 
                    new { prop.PerfumeID, prop.PerfumeryID });
                        
        }


        public DbSet<Perfume> Perfumes { get; set; }
        public DbSet<Perfumery> Perfumerias { get; set; }
        public DbSet<Brand> Marcas { get; set; }
        public DbSet<Gender> Generos { get; set; }
        public DbSet<Volume> Volumes { get; set; }
    }
}
