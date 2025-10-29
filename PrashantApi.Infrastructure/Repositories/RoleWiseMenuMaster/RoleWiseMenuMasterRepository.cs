using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PrashantApi.Application.Interfaces.RoleWiseMenuMaster;
using PrashantApi.Domain.Entities.RoleWiseMenuMaster;
using PrashantApi.Infrastructure.Connection;
using System.Data;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;


namespace PrashantApi.Infrastructure.Repositories.RoleWiseMenuMaster
{
    public class RoleWiseMenuMasterRepository(IDbConnectionString dbConnectionString) : IRoleWiseMenuMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<CommandResult> AddAsync(RoleWiseMenuMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("MenuId", typeof(int));
                table.Columns.Add("RoleId", typeof(int));
                table.Columns.Add("CreatedBy", typeof(int));
                table.Columns.Add("IsActive", typeof(bool));
                table.Columns.Add("IsObsolete", typeof(bool));

                foreach (var menuId in entity.MenuId)
                    table.Rows.Add(0, menuId, entity.RoleId, entity.CreatedBy, entity.IsActive, entity.IsObsolete);

                var parameters = new DynamicParameters();
                parameters.Add("@RoleWiseMenuMasterTVP", table.AsTableValuedParameter("dbo.Type_RoleWiseMenuMasterNew"));
                parameters.Add("@mode", "INSERT");

                var output = await connection.ExecuteAsync(
                    SqlConstants.RoleWiseMenuMaster.RoleWiseMenuMasterr,
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

        public async Task<CommandResult> UpdateAsync(RoleWiseMenuMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("MenuId", typeof(int));
                table.Columns.Add("RoleId", typeof(int));
                table.Columns.Add("ModifiedBy", typeof(int));
                table.Columns.Add("IsActive", typeof(bool));
                table.Columns.Add("IsObsolete", typeof(bool));

                foreach (var menuId in entity.MenuId)
                    table.Rows.Add(entity.Id, menuId, entity.RoleId, entity.ModifiedBy, entity.IsActive, entity.IsObsolete);

                var parameters = new DynamicParameters();
                parameters.Add("@RoleWiseMenuMasterTVP", table.AsTableValuedParameter("dbo.Type_RoleWiseMenuMasterNew"));
                parameters.Add("@mode", "UPDATE");

                var output = await connection.ExecuteAsync(
                    SqlConstants.RoleWiseMenuMaster.RoleWiseMenuMasterr,
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

        public async Task<dynamic> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();

            var result = await connection.QueryAsync<dynamic>(
                SqlConstants.RoleWiseMenuMaster.GetAllRoleWiseMenuMasters,
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
                SqlConstants.RoleWiseMenuMaster.GetRoleWiseMenuMasterById,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}
