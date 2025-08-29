using PrashantApi.Domain.Entities;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<CommandResult<UserModel>> LoginAsync(string username, string password);
        //Task AddAsync(User user); // useful for seeding
    }
}
