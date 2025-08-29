//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PrashantApi.Infrastructure.Repositories.UserRegistration
//{
//    class UserRegistrationRepository
//    {
//    }
//}
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrashantApi.Application.DTOs.Auth;
using PrashantApi.Application.DTOs.UserRegistration;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.Logging;
using PrashantApi.Application.Interfaces.UserRegistration;
using PrashantApi.Domain.Entities;
using PrashantApi.Infrastructure.Common;
using PrashantApi.Infrastructure.Data;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;


namespace PrashantApi.Infrastructure.Repositories
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly ILog _log;
        private readonly ISqlServerDataAccess sqlServerDataAccess;

        public UserRegistrationRepository( ILog log, ISqlServerDataAccess _sqlServerDataAccess)
        {
            _log = log;
            this.sqlServerDataAccess = _sqlServerDataAccess;
        }
        public async Task<CommandResult> RegisterAsync(RegisterRequest request)
        {
            try
            { 
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", request.FirstName);
                parameters.Add("@LastName", request.LastName);
                parameters.Add("@UserName", request.Username);
                parameters.Add("@Password", request.Password);    
                parameters.Add("@CreatedBy", "Admin");

                //await connection.ExecuteAsync(
                //    SqlConstants.UserRegistration.usp_UserRegister,
                //    parameters,
                //    commandType: CommandType.StoredProcedure);

                await sqlServerDataAccess.ExecuteAsync(
                      SqlConstants.UserRegistration.usp_UserRegister,
                      parameters,
                      CommandType.StoredProcedure);

                return CommandResult.SuccessWithOutput("User registered successfully.");
            }
            catch (SqlException ex)
            {
                 _log.LogException(ex);
                return CommandResult.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                _log.LogException(ex);
                return CommandResult.Fail("Registration failed due to an internal error.");
            }
        }
    }
}
