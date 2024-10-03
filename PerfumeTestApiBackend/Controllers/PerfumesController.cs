using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeTestApiBackend.DataAccess;
using PerfumeTestApiBackend.Models;

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
        public async Task<ActionResult<ICollection<Perfume>>> GetAllAsync()
        {
            if (_dbContext.Perfumes == null)
            {
                return NotFound();
            }
            return await _dbContext.Perfumes.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            // use select loading
            var perfume = await _dbContext.Perfumes.Select( p => new
            {
                id = p.Id,
                name = p.Name,
                gender = p.Gender.TypeGender,
                brand = p.Brand.Name,
                volume = p.Volume.Quantity,
                price = p.Price,
                stocks = p.Stocks.Select(s => new
                {
                    perfumery = s.Perfumery.Name,
                    address = s.Perfumery.Address,
                    amount = s.Amount
                })
            }).FirstOrDefaultAsync( r => r.id == id );

            if (perfume == null)
            {
                return NotFound();
            }

            return Ok(perfume);
        } 
    }
}
