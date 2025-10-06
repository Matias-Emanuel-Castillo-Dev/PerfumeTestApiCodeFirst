using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PerfumeTestApiBackend.Models;
using PerfumeTestApiBackend.Models.DTOs;
using PerfumeTestApiBackend.Models.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PerfumeTestApiBackend.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public ResponseAuthentication GenerateToken(UserLoginDTO usuario)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim("email", usuario.Email),
            new Claim("name", usuario.Name),
            new Claim("role", usuario.Role)
            };

            var expire = DateTime.Now.AddMinutes(_jwtSettings.ExpireMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expire,
                signingCredentials: credentials);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new ResponseAuthentication() { Token = tokenString, Expire = expire };
        }
    }
}
