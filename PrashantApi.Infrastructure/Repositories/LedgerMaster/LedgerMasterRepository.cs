using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PrashantApi.Application.Interfaces.LedgerMaster;
using PrashantApi.Domain.Entities.LedgerMaster;
using PrashantApi.Infrastructure.Connection;
using System.Data;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;

namespace PrashantApi.Infrastructure.Repositories.LedgerMaster
{
    public class LedgerMasterRepository(IDbConnectionString dbConnectionString) : ILedgerMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<CommandResult> AddAsync(LedgerMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@Id", 0);
                parameters.Add("@LedgerCode", entity.LedgerCode);
                parameters.Add("@LedgerName", entity.LedgerName);
                parameters.Add("@MainGroupId", entity.MainGroupId);
                parameters.Add("@SubGroupId", entity.SubGroupId);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@Mode", "INSERT");

                var output = await connection.ExecuteAsync(
                    SqlConstants.LedgerMaster.LedgerMasterr,
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

        public async Task<CommandResult> UpdateAsync(LedgerMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@Id", entity.Id);
                parameters.Add("@LedgerCode", entity.LedgerCode);
                parameters.Add("@LedgerName", entity.LedgerName);
                parameters.Add("@MainGroupId", entity.MainGroupId); 
                parameters.Add("@SubGroupId", entity.SubGroupId);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@Mode", "UPDATE");

                var output = await connection.ExecuteAsync(
                    SqlConstants.LedgerMaster.LedgerMasterr,
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
                SqlConstants.LedgerMaster.GetAllLedgerMaster,
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
                SqlConstants.LedgerMaster.GetLedgerMasterById,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}

