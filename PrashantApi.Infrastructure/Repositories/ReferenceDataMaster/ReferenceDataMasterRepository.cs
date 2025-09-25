using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PrashantApi.Application.DTOs.ReferenceDataMaster;
using PrashantApi.Application.Interfaces.ReferenceDataMaster;
using System.Data;

namespace PrashantApi.Infrastructure.Repositories.ReferenceDataMaster
{
    public class ReferenceDataMasterRepository : IReferenceDataMasterRepository
    {
        private readonly string _connectionString;

        public ReferenceDataMasterRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PrashantConnectionString");

            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new InvalidOperationException(
                    "Database connection string 'PrashantConnectionString' is missing in appsettings.json."
                );
            }
        }


        public async Task<List<RoleDto>> GetRoleNamesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var result = await connection.QueryAsync<RoleDto>(
                "usp_ReferenceData",
                new { mode = "GetRoleName" },
                commandType: CommandType.StoredProcedure
            );

            return result.AsList();
        }

        public async Task<List<MenuDto>> GetMenuNamesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var result = await connection.QueryAsync<MenuDto>(
                "usp_ReferenceData",
                new { mode = "GetMenuName" },
                commandType: CommandType.StoredProcedure
            );

            return result.AsList();
        }


        public async Task<List<UserDto>> GetUserNamesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var result = await connection.QueryAsync<UserDto>(
                "usp_ReferenceData",
                new { mode = "GetUserName" },
                commandType: CommandType.StoredProcedure
            );

            return result.AsList();
        }
    }
}
