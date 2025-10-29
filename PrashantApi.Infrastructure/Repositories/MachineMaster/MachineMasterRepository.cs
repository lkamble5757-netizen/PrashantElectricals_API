using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PrashantApi.Application.Interfaces.MachineMaster;
using PrashantApi.Domain.Entities.MachineMaster;
using PrashantApi.Infrastructure.Connection;
using System.Data;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;

namespace PrashantApi.Infrastructure.Repositories.MachineMaster
{
    public class MachineMasterRepository(IDbConnectionString dbConnectionString) : IMachineMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<CommandResult> AddAsync(MachineMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", 0);
                parameters.Add("@BrandName", entity.BrandName);
                parameters.Add("@HpKw", entity.HpKw);
                parameters.Add("@Slot", entity.Slot);
                parameters.Add("@RPM", entity.RPM);
                parameters.Add("@Pitch", entity.Pitch);
                parameters.Add("@Gauge", entity.Gauge);
                parameters.Add("@AlterGauge", entity.AlterGauge);
                parameters.Add("@Turn", entity.Turn);
                parameters.Add("@CoilMeasurement", entity.CoilMeasurement);
                parameters.Add("@WindingType", entity.WindingType);
                parameters.Add("@ConnectionType", entity.ConnectionType);
                parameters.Add("@StatorLobby", entity.StatorLobby);
                parameters.Add("@CoilGroupWeight", entity.CoilGroupWeight);
                parameters.Add("@TotalWireWeight", entity.TotalWireWeight);
                parameters.Add("@PhaseSize", entity.PhaseSize);
                parameters.Add("@Amperes", entity.Amperes);
                parameters.Add("@WindingDate", entity.WindingDate);
                parameters.Add("@GpDc", entity.GpDc);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@mode", "INSERT");

                var output = await connection.ExecuteAsync(
                    SqlConstants.MachineMaster.MachineMasterr,
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

        public async Task<CommandResult> UpdateAsync(MachineMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id);
                parameters.Add("@BrandName", entity.BrandName);
                parameters.Add("@HpKw", entity.HpKw);
                parameters.Add("@Slot", entity.Slot);
                parameters.Add("@RPM", entity.RPM);
                parameters.Add("@Pitch", entity.Pitch);
                parameters.Add("@Gauge", entity.Gauge);
                parameters.Add("@AlterGauge", entity.AlterGauge);
                parameters.Add("@Turn", entity.Turn);
                parameters.Add("@CoilMeasurement", entity.CoilMeasurement);
                parameters.Add("@WindingType", entity.WindingType);
                parameters.Add("@ConnectionType", entity.ConnectionType);
                parameters.Add("@StatorLobby", entity.StatorLobby);
                parameters.Add("@CoilGroupWeight", entity.CoilGroupWeight);
                parameters.Add("@TotalWireWeight", entity.TotalWireWeight);
                parameters.Add("@PhaseSize", entity.PhaseSize);
                parameters.Add("@Amperes", entity.Amperes);
                parameters.Add("@WindingDate", entity.WindingDate);
                parameters.Add("@GpDc", entity.GpDc);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@mode", "UPDATE");

                var output = await connection.ExecuteAsync(
                    SqlConstants.MachineMaster.MachineMasterr,
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
                SqlConstants.MachineMaster.GetAllMachineMaster,
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
                SqlConstants.MachineMaster.GetMachineMasterById,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}


