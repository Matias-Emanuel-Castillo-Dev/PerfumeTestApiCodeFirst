using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PerfumeTestApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly DbContext _dbContext;

        public GendersController( DbContext dbContext )
        {
            _dbContext = dbContext;
        }
    }
}
