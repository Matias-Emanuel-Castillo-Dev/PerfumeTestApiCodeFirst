using PerfumeTestApiBackend.Models.DTOs;
using PerfumeTestApiBackend.Models.Jwt;

namespace PerfumeTestApiBackend.Services
{
    public interface ITokenService
    {
        ResponseAuthentication GenerateToken(UserLoginDTO usuario);
    }
}