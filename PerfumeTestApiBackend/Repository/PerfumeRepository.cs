using PerfumeTestApiBackend.DataAccess;
using PerfumeTestApiBackend.Models;
using PerfumeTestApiBackend.Models.DTOs;
using PerfumeTestApiBackend.Services;

namespace PerfumeTestApiBackend.Repository
{
    public class PerfumeRepository : RepositoryAbstract<Perfume, PerfumeTestDbContext> , IPerfumeRepository
    {
        public PerfumeRepository(PerfumeTestDbContext context) : base(context){}

        //    public async Task<IEnumerable<PerfumeDTO>> GetAllAsync()
        //{
        //    return await GetAllAsync(
        //        selector: p => new PerfumeDTO()
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            Gender = p.Gender.TypeGender,
        //            Brand = p.Brand.Name,
        //            Volume = p.Volume.Quantity,
        //            Price = p.Price,
        //            Stock = p.Stocks.Select(s => new PerfumeryDTO()
        //            {
        //                Name = s.Perfumery.Name,
        //                Address = s.Perfumery.Address,
        //                Amount = s.Amount
        //            }).ToList(),
        //            Available = p.Available
        //        },
        //        includes: p => p.Gender,
        //        p => p.Brand, 
        //        p => p.Volume,
        //        p => p.Stocks
        //    );
        //}

        public async Task<IEnumerable<PerfumeDTO>> GetAllAsync()
        {
            return await GetAllAsync(
                selector: p => new PerfumeDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Gender = p.Gender.TypeGender,
                    Brand = p.Brand.Name,
                    Volume = p.Volume.Quantity,
                    Price = p.Price,
                    Stock = p.Stocks.Select(s => new PerfumeryDTO()
                    {
                        Name = s.Perfumery.Name,
                        Address = s.Perfumery.Address,
                        Amount = s.Amount
                    }).ToList(),
                    Available = p.Available
                }
            );
        }

        public async Task<PerfumeDTO?> GetByIdAsync(int id)
        {
            return await GetByIdAsync(
                id: id,
                selector: p => new PerfumeDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Gender = p.Gender.TypeGender,  // EF Core entiende que necesita JOIN
                    Brand = p.Brand.Name,          // EF Core entiende que necesita JOIN  
                    Volume = p.Volume.Quantity,    // EF Core entiende que necesita JOIN
                    Price = p.Price,
                    Stock = p.Stocks.Select(s => new PerfumeryDTO()
                    {
                        Name = s.Perfumery.Name,     // EF Core entiende JOIN anidado
                        Address = s.Perfumery.Address,
                        Amount = s.Amount
                    }).ToList(),
                    Available = p.Available
                }
            );
        }
    }
}
