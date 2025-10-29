using Dapper;
using PrashantApi.Application.Interfaces.RoleMaster;
using PrashantApi.Domain.Entities.RoleMaster;
using PrashantApi.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Repositories.RoleMaster
{   
    public class RoleMasterRepository(IDbConnectionString dbConnectionString) : IRoleMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<CommandResult> AddAsync(RoleMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0);
            parameters.Add("@Role", entity.Role);
            parameters.Add("@Description", entity.Description);
            parameters.Add("@IsActive", entity.IsActive);
            parameters.Add("@CreatedBy", entity.CreatedBy);
            parameters.Add("@mode", "INSERT");

            return await connection.QuerySingleAsync<CommandResult>(
                SqlConstants.RoleMaster.RoleMasterr,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<CommandResult> UpdateAsync(RoleMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", entity.Id);
            parameters.Add("@Role", entity.Role);
            parameters.Add("@Description", entity.Description);
            parameters.Add("@IsActive", entity.IsActive);
            parameters.Add("@ModifiedBy", entity.ModifiedBy);
            parameters.Add("@mode", "UPDATE");

            return await connection.QuerySingleAsync<CommandResult>(
                SqlConstants.RoleMaster.RoleMasterr,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();

            var result = await connection.QueryAsync<dynamic>(
                SqlConstants.RoleMaster.GetAllRoles,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<dynamic> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var result = await connection.QueryAsync<dynamic>(
                SqlConstants.RoleMaster.GetRoleById,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

    }
}
