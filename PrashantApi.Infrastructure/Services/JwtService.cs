using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrashantApi.Application.DTOs.Auth;
using PrashantApi.Application.Interfaces;
using PrashantApi.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrashantApi.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        // new
        public LoginResponse GenerateToken(UserModel user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]!));

            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),  // Unique user ID 
                new Claim("Id", user.Id ),
                new Claim("FullName", user.FullName ?? string.Empty),
                new Claim("Email", user.Email ?? string.Empty),
                new Claim("RoleIds", user.RoleIds ?? string.Empty)
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                signingCredentials: creds
            );

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }

    }
}
