using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeTestApiBackend.DataAccess;
using PerfumeTestApiBackend.Migrations;
using PerfumeTestApiBackend.Models.DTOs;
using PerfumeTestApiBackend.Models;
using PerfumeTestApiBackend.Services;
using PerfumeTestApiBackend.Repository;
using PerfumeTestApiBackend.Models.Jwt;

namespace PerfumeTestApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IEncriptionService _encriptionService;
        private readonly UserRepository _repository;
        private readonly ITokenService tokenService;

        public LoginController(IEncriptionService encriptionService,UserRepository repository, ITokenService tokenService)
        {
            _encriptionService = encriptionService;
            _repository = repository;
            this.tokenService = tokenService;
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

            await _repository.AddAsync(entity);
            return Ok(entity);
        
        }

        [HttpPost("initSession")]
        public async Task<ActionResult<ResponseAuthentication>> Login(Credentials credentials)
        {
            var user = await _repository.GetByEmailAsync(credentials.Email);
            if (user == null) {
                ModelState.AddModelError("Credentials", "Invalid credentials");
                return ValidationProblem(ModelState);
            }           

            bool result = _encriptionService.VerifyPassword(credentials.Password, user.Password);

            if (!result)
            {
                ModelState.AddModelError("Credentials", "Invalid credentials");
                return ValidationProblem(ModelState);
            }

            var responseAuth = tokenService.GenerateToken(user);

            return Ok(responseAuth);

        }
    }
}
