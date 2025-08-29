using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs;
using PrashantApi.Application.DTOs.Auth;
using PrashantApi.Application.DTOs.UserRegistration;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.UserRegistration;
using PrashantApi.Infrastructure.Services;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public readonly IUserRegistrationService _userRegistrationService; 
        public AuthController(IUserRegistrationService userRegistrationService, IAuthService authService)
        {
            _authService = authService;
            _userRegistrationService = userRegistrationService;
        }
        //test login
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Username and password are required.");

            var response = await _authService.AuthenticateAsync(request);

            if (response == null)
                return Unauthorized("Invalid credentials");

            return Ok(response);
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(CommandResult.Fail("Username and password are required."));

            var response = await _userRegistrationService.RegisterAsync(request);

            if (!response.IsSuccess)
                // return the whole CommandResult so client always sees { isSuccess, failureReason, output }
                return Conflict(response);

            return Ok(response);
        }
    }
}
