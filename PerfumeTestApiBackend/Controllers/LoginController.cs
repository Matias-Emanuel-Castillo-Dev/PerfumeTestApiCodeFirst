using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeTestApiBackend.DataAccess;
using PerfumeTestApiBackend.Migrations;
using PerfumeTestApiBackend.Models.DTOs;
using PerfumeTestApiBackend.Models;
using PerfumeTestApiBackend.Services;

namespace PerfumeTestApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IEncriptionService _encriptionService;
        private PerfumeTestDbContext _context;

        public LoginController(IEncriptionService encriptionService, PerfumeTestDbContext context)
        {
            _encriptionService = encriptionService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserCreateDTO user) {

            string encription = _encriptionService.HashPassword(user.Password);
            User entity = new User()
            {
                CategoryId = user.Category,
                Name = user.Name,
                Email = user.Email,
                LastName = user.LastName,
                PasswordHash = encription               
            };

            await _context.AddAsync(entity);
            _context.SaveChanges();
            return Ok(entity);
        
        }

        [HttpPost("initSession")]
        public async Task<ActionResult> Login(Credentials credentials)
        {
            //string pass = _encriptionService.
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == credentials.Email);
            if (user == null)
            {
                return NotFound();
            }

            bool result = _encriptionService.VerifyPassword(credentials.Password, user.PasswordHash);

            if (!result)
            {
                return Unauthorized("credenciales invalidas");
            }

            return Ok("Bienvenido");

        }
    }
}
