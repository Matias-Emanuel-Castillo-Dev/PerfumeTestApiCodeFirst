using Microsoft.EntityFrameworkCore;
using PerfumeTestApiBackend.DataAccess;
using PerfumeTestApiBackend.Models;
using PerfumeTestApiBackend.Models.DTOs;

namespace PerfumeTestApiBackend.Repository
{
    public class UserRepository : RepositoryAbstract<User, PerfumeTestDbContext>
    {
        public UserRepository(PerfumeTestDbContext context) : base(context){}

        public async Task<UserLoginDTO>GetByEmailAsync(string email)
        {
            return await GetEntityWithFilter(
                filter: u => u.Email == email,
                selector: u => new UserLoginDTO
                {
                    Email = u.Email,
                    Name = u.Name,
                    Password = u.PasswordHash,
                    Role = u.Category.Role
                }
                );
        }
    }
}
