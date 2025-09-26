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

namespace PrashantApi.Infrastructure.Repositories.RoleWiseMenuMaster
{
    public class RoleWiseMenuMasterRepository(IDbConnectionString dbConnectionString) : IRoleWiseMenuMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task AddAsync(RoleWiseMenuMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("MenuId", typeof(int));
                table.Columns.Add("RoleId", typeof(int));
                table.Columns.Add("CreatedBy", typeof(string));
                table.Columns.Add("CreatedOn", typeof(string));
                table.Columns.Add("IsActive", typeof(bool));
                table.Columns.Add("IsObsolete", typeof(bool));

                foreach (var menuId in entity.MenuId)
                {
                    table.Rows.Add(0, menuId, entity.RoleId, entity.CreatedBy, "", entity.IsActive, entity.IsObsolete);
                }

                var parameters = new DynamicParameters();
                parameters.Add("@RoleWiseMenuMasterTVP", table.AsTableValuedParameter("dbo.Type_RoleWiseMenuMasterNew"));
                parameters.Add("@mode", "INSERT");

                await connection.ExecuteAsync(
                    "usp_SaveRoleWiseMenuMaster",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAsync(RoleWiseMenuMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("MenuId", typeof(int));
                table.Columns.Add("RoleId", typeof(int));
                table.Columns.Add("CreatedBy", typeof(string));
                table.Columns.Add("CreatedOn", typeof(string));
                table.Columns.Add("IsActive", typeof(bool));
                table.Columns.Add("IsObsolete", typeof(bool));

                foreach (var menuId in entity.MenuId)
                {
                    table.Rows.Add(entity.Id, menuId, entity.RoleId, entity.CreatedBy, "", entity.IsActive, entity.IsObsolete);
                }

                var parameters = new DynamicParameters();
                parameters.Add("@RoleWiseMenuMasterTVP", table.AsTableValuedParameter("Type_RoleWiseMenuMasterNew"));
                parameters.Add("@mode", "UPDATE");

                await connection.ExecuteAsync(
                    "usp_SaveRoleWiseMenuMaster",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<dynamic>> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();

            var result = await connection.QueryAsync<dynamic>(
                "usp_GetAllRoleWiseMenuMasters",
                commandType: CommandType.StoredProcedure
            );

            return result.AsList();
        }

        public async Task<List<dynamic>> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var result = await connection.QueryAsync<dynamic>(
                "usp_GetRoleWiseMenuMasterById",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.AsList(); // ✅ FIXED: QueryAsync + AsList()
        }
    }
}
