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

 

        public async Task<CommandResult> BulkInsertAsync(List<MachineMasterModel> machines)
        {
            if (machines == null || machines.Count == 0)
                return CommandResult.Fail("No machine data to insert.");

            using var connection = _dbConnectionString.GetConnection();

            try
            {
                var table = new DataTable();
                table.Columns.Add("BrandName", typeof(string));
                table.Columns.Add("HpKw", typeof(int));
                table.Columns.Add("Slot", typeof(int));
                table.Columns.Add("RPM", typeof(int));
                table.Columns.Add("Pitch", typeof(string));
                table.Columns.Add("Gauge", typeof(string));
                table.Columns.Add("AlterGauge", typeof(string));
                table.Columns.Add("Turn", typeof(int));
                table.Columns.Add("CoilMeasurement", typeof(string));
                table.Columns.Add("WindingType", typeof(int));
                table.Columns.Add("ConnectionType", typeof(string));
                table.Columns.Add("StatorLobby", typeof(string));
                table.Columns.Add("CoilGroupWeight", typeof(decimal));
                table.Columns.Add("TotalWireWeight", typeof(decimal));
                table.Columns.Add("PhaseSize", typeof(string));
                table.Columns.Add("Amperes", typeof(decimal));
                table.Columns.Add("WindingDate", typeof(DateTime));
                table.Columns.Add("GpDc", typeof(string));
                table.Columns.Add("CreatedBy", typeof(int));

                foreach (var m in machines)
                {
                    table.Rows.Add(
                        m.BrandName,
                        m.HpKw,
                        m.Slot,
                        m.RPM,
                        m.Pitch,
                        m.Gauge,
                        m.AlterGauge,
                        m.Turn,
                        m.CoilMeasurement,
                        m.WindingType,
                        m.ConnectionType,
                        m.StatorLobby,
                        m.CoilGroupWeight,
                        m.TotalWireWeight,
                        m.PhaseSize,
                        m.Amperes,
                        m.WindingDate,
                        m.GpDc,
                        m.CreatedBy
                    );
                }

                var parameters = new DynamicParameters();
                parameters.Add( "@MachineMaster",  table.AsTableValuedParameter("dbo.MachineMasterT"));

                await connection.ExecuteAsync(
                     SqlConstants.MachineMaster.ImportExcel,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return CommandResult.SuccessWithOutput("Machines imported successfully");
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }

    }
}


