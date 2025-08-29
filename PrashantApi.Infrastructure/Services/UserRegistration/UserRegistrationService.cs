using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
 
using PrashantApi.Application.Configurations;
using PrashantApi.Application.DTOs.UserRegistration;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.UserRegistration;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Infrastructure.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly JwtSettings _jwt;
        private readonly IJwtService _jwtService;

        public UserRegistrationService(
            IUserRegistrationRepository userRegistrationRepository,
            IOptions<JwtSettings> jwtOptions,
            IJwtService jwtService)
        {
            _userRegistrationRepository = userRegistrationRepository;
            _jwt = jwtOptions.Value;
            _jwtService = jwtService;
        }

        public async Task<CommandResult> RegisterAsync(RegisterRequest request)
        {
            return await _userRegistrationRepository.RegisterAsync(request);

        }

    }
}
