using Microsoft.EntityFrameworkCore;
using PrashantApi.Application.Interfaces;
using PrashantApi.Domain.Entities;
using PrashantApi.Infrastructure.Data;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System.Data;
using Dapper;
using PrashantApi.Application.Interfaces.Logging;
using PrashantApi.Infrastructure.Entities;
using PrashantApi.Infrastructure.Connection;
namespace PrashantApi.Infrastructure.Repositories;

public class UserRepository(IDbConnectionString connectionString, ILog log) :  IUserRepository  
{
    private readonly IDbConnectionString _connectionString = connectionString;
    private readonly ILog _log = log;

    public async Task<CommandResult<UserModel>> LoginAsync(string userName, string password)  
    {
        try
        {
            using var connection = _connectionString.GetConnection();

            var user = await connection.QuerySingleOrDefaultAsync<UserModel>(
                SqlConstants.UserMaster.usp_GetLoginInfo,
                new { Username = userName, Password = password },
                commandType: CommandType.StoredProcedure);

            if (user == null)
                return CommandResult<UserModel>.Fail("Invalid username or password.");

            return CommandResult<UserModel>.SuccessWithOutput(user);
        }
        catch (Exception ex)
        {
            _log.LogException(ex);
            return CommandResult<UserModel>.Fail("Login failed due to an internal error.");
        }
    }

    public async Task AddAsync(UserModel user)
    {
        using var connection = _connectionString.GetConnection(); 
        throw new NotImplementedException();
    }
}
