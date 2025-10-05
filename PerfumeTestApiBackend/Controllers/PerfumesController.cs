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
        //private readonly PerfumeTestDbContext _dbContext;
        private readonly IPerfumeRepository _repository;

        public PerfumesController(PerfumeTestDbContext dbContext, IPerfumeRepository repository)
        {
            //_dbContext = dbContext;
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

       
    }
}
