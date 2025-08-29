using Microsoft.Extensions.Options;
using PrashantApi.Application.Configurations;
using PrashantApi.Application.DTOs;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwt;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository, IOptions<JwtSettings> jwtOptions, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwt = jwtOptions.Value;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto?> AuthenticateAsync(LoginRequestDto request)
        {
            var result = await _userRepository.LoginAsync(request.Username, request.Password);
            if (result == null || result.Data == null) return null;

            //var token = _jwtService.GenerateToken(result.Data.Username, new List<string> { result.Data.Role });
            var token = _jwtService.GenerateToken(result.Data);


            return new AuthResponseDto
            {
                Token = token.Token, 
            };
        }
    }
}
