 using PrashantApi.Application.DTOs.UserRegistration;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.UserRegistration
{
    public interface IUserRegistrationService
    {
        Task<CommandResult> RegisterAsync(RegisterRequest request);
    }
}
