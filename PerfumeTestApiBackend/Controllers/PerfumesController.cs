using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeTestApiBackend.DataAccess;
using PerfumeTestApiBackend.Models;
using PerfumeTestApiBackend.Models.DTOs;
using PerfumeTestApiBackend.Repository;
using PerfumeTestApiBackend.Services;

namespace PerfumeTestApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumesController : ControllerBase
    {
        private readonly PerfumeRepository _repository;

        public PerfumesController(PerfumeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfumeDTO>>> GetAllAsyncWithProjectTo()
        {
            IEnumerable<PerfumeDTO> result = await _repository.GetAllAsync();

            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PerfumeDTO>> GetAsyncById(int id)
        {
            PerfumeDTO resp = await _repository.GetByIdAsync(id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(PerfumeCreateDTO perfume)
        {
            var Response = await _repository.AddAsync(
                new Perfume
                {
                    Name = perfume.Name,
                    Price = perfume.Price,
                    Available = perfume.Available,
                    GenderID = perfume.Gender,
                    BrandID = perfume.Brand,
                    VolumeID = perfume.Volume,
                    Stocks = perfume.Stocks.Select(s=> new Stock
                    {
                        PerfumeryID = s.Perfumeria,
                        Amount = s.Quantity,
                    }).ToList() ?? new List<Stock>()                    
                });

            var perfumeDto = await _repository.GetByIdAsync(Response.Id);

            return CreatedAtAction(nameof(GetAsyncById), new { id = Response.Id }, perfumeDto);

        }

       
    }
}
