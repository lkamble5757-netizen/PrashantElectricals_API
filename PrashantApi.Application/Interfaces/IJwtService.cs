using PrashantApi.Application.DTOs.Auth;
using PrashantApi.Domain.Entities;

namespace PrashantApi.Application.Interfaces
{
    public interface IJwtService
    {
        LoginResponse GenerateToken(UserModel user);
    }
}
