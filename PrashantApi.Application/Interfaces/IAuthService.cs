using PrashantApi.Application.DTOs;

namespace PrashantApi.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto?> AuthenticateAsync(LoginRequestDto request);
}
