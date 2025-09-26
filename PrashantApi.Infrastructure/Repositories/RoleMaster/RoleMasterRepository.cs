using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using PrashantApi.Application.Interfaces.RoleMaster;
using PrashantApi.Domain.Entities.RoleMaster;
using PrashantApi.Infrastructure.Connection;

namespace PrashantApi.Infrastructure.Repositories.RoleMaster
{
    public class RoleMasterRepository(IDbConnectionString dbConnectionString) : IRoleMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<int> AddAsync(RoleMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0);
            parameters.Add("@Role", entity.Role);
            parameters.Add("@Description", entity.Description);
            parameters.Add("@IsActive", entity.IsActive);
            parameters.Add("@CreatedBy", entity.CreatedBy);
            parameters.Add("@mode", "INSERT");

            return await connection.QuerySingleAsync<int>(
                "usp_SaveRoleMaster",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateAsync(RoleMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", entity.Id);
            parameters.Add("@Role", entity.Role);
            parameters.Add("@Description", entity.Description);
            parameters.Add("@IsActive", entity.IsActive);
            parameters.Add("@ModifiedBy", entity.ModifiedBy);
            parameters.Add("@mode", "UPDATE");

            return await connection.QuerySingleAsync<int>(
                "usp_SaveRoleMaster",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<List<RoleMasterModel>> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();

            var result = await connection.QueryAsync<RoleMasterModel>(
                "usp_GetAllRoles",
                commandType: CommandType.StoredProcedure
            );

            return result.AsList();
        }

        public async Task<RoleMasterModel> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return await connection.QueryFirstOrDefaultAsync<RoleMasterModel>(
                "usp_GetRoleById",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
