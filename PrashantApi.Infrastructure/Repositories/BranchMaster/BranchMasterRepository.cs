using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PrashantApi.Application.DTOs.BranchMaster;
using PrashantApi.Application.Interfaces.BranchMaster;
using PrashantApi.Application.Interfaces.Logging;
using PrashantApi.Domain.Entities;
using PrashantApi.Domain.Entities.BranchMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Repositories.BranchMaster
{
    public class BranchMasterRepository : IBranchMasterRepository
    {
        private readonly IDbConnectionString _connectionString;

        public BranchMasterRepository(IConfiguration configuration, IDbConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<BranchMasterModel?> GetByIdAsync(int branchId)
        {
            //dummy sql call add your logic here 
            using var connection = _connectionString.GetConnection();
            var query = "SELECT BranchId, BranchName, Address FROM BranchMaster WHERE BranchId = @Id";
            return await connection.QueryFirstOrDefaultAsync<BranchMasterModel>(
                query, new { Id = branchId });
        }

        public async Task<int> AddAsync(BranchMasterModel model)
        {

            //dummy sql call add your logic here 
            using var connection = _connectionString.GetConnection();
            var sql = @"INSERT INTO BranchMaster (BranchName, Address)
                    VALUES (@BranchName, @Address);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

            return await connection.QuerySingleAsync<int>(sql, model);
        }
    }
}
