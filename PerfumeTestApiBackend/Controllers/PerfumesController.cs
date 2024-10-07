using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeTestApiBackend.DataAccess;
using PerfumeTestApiBackend.Models;
using PerfumeTestApiBackend.Models.DTOs;

namespace PerfumeTestApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumesController : ControllerBase
    {
        private readonly PerfumeTestDbContext _dbContext;

        public PerfumesController(PerfumeTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<PerfumeDTO>>> GetAllAsync()
        {
            if (_dbContext.Perfumes == null)
            {
                return NotFound();
            }
            return await _dbContext.Perfumes.Select(p => new PerfumeDTO()
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
            }).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PerfumeDTO>> GetByIdAsync(int id)
        {
            // use select loading
            var perfume = await _dbContext.Perfumes.Select( p => 
            new PerfumeDTO()
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
            }).FirstOrDefaultAsync( r => r.Id == id );

            if (perfume == null)
            {
                return NotFound();
            }

            return Ok(perfume);
        } 
    }
}
