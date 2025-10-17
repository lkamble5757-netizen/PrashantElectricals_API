using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PrashantApi.Application.Interfaces.UserRoleAssignMaster;
using PrashantApi.Domain.Entities.UserRoleAssignMaster;
using PrashantApi.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System.Data;

namespace PrashantApi.Infrastructure.Repositories.UserRoleAssignMaster
{
    public class UserRoleAssignMasterRepository(IDbConnectionString dbConnectionString) : IUserRoleAssignMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<CommandResult> AddAsync(UserRoleAssignMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("UserId", typeof(int));
                table.Columns.Add("RoleId", typeof(int));
                table.Columns.Add("CreatedBy", typeof(int));
                table.Columns.Add("IsActive", typeof(bool));
                table.Columns.Add("IsObsolete", typeof(bool));

                foreach (var roleId in entity.RoleId)
                {
                    table.Rows.Add(0, entity.UserId, roleId, entity.CreatedBy, entity.IsActive, entity.IsObsolete);
                }


                var parameters = new DynamicParameters();
                parameters.Add("@UserRoleAssignMasterTVP", table.AsTableValuedParameter("dbo.Type_UserAssignRoleMasterNew"));
                parameters.Add("@mode", "INSERT");

               var output =  await connection.ExecuteAsync(
                    SqlConstants.UserRoleAssignMaster.usp_SaveUserRoleAssignMaster,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return CommandResult.SuccessWithOutput(output);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }

        public async Task<CommandResult> UpdateAsync(UserRoleAssignMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("UserId", typeof(int));
                table.Columns.Add("RoleId", typeof(int));
                table.Columns.Add("ModifiedBy", typeof(int));
                table.Columns.Add("IsActive", typeof(bool));
                table.Columns.Add("IsObsolete", typeof(bool));


                foreach (var roleId in entity.RoleId)
                {
                    table.Rows.Add(entity.Id, entity.UserId, roleId, entity.ModifiedBy, entity.IsActive, entity.IsObsolete);
                }
    

                var parameters = new DynamicParameters();
                parameters.Add("@UserRoleAssignMasterTVP", table.AsTableValuedParameter("dbo.Type_UserAssignRoleMasterNew"));
                parameters.Add("@mode", "UPDATE");

                var output = await connection.ExecuteAsync(
                    SqlConstants.UserRoleAssignMaster.usp_SaveUserRoleAssignMaster,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return CommandResult.SuccessWithOutput(output);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();

            var result = await connection.QueryAsync<dynamic>(
                SqlConstants.UserRoleAssignMaster.usp_GetAllUserRoleAssignMasters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<IEnumerable<dynamic>> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var result = await connection.QueryAsync<dynamic>(
                SqlConstants.UserRoleAssignMaster.usp_GetUserRoleAssignMasterById,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}
