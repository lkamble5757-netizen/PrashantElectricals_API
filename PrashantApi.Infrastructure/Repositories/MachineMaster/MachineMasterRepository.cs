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

namespace PrashantApi.Infrastructure.Repositories.MachineMaster
{
    public class MachineMasterRepository(IDbConnectionString dbConnectionString) : IMachineMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<int> AddAsync(MachineMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0);
            parameters.Add("@BrandName", entity.BrandName);
            parameters.Add("@HP_KW", entity.HP_KW);
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
            parameters.Add("@GPDC", entity.GPDC);
            parameters.Add("@CreatedBy", entity.CreatedBy);
            parameters.Add("@IsActive", entity.IsActive);
            parameters.Add("@mode", "INSERT");

            return await connection.QuerySingleAsync<int>(
                "usp_SaveMachineMaster",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateAsync(MachineMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", entity.Id);
            parameters.Add("@BrandName", entity.BrandName);
            parameters.Add("@HP_KW", entity.HP_KW);
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
            parameters.Add("@GPDC", entity.GPDC);
            parameters.Add("@ModifiedBy", entity.ModifiedBy);
            parameters.Add("@IsActive", entity.IsActive);
            parameters.Add("@mode", "UPDATE");

            return await connection.QuerySingleAsync<int>(
                "usp_SaveMachineMaster",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<List<MachineMasterModel>> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();

            var result = await connection.QueryAsync<MachineMasterModel>(
                "usp_GetAllMachines",
                commandType: CommandType.StoredProcedure
            );

            return result.AsList();
        }

        public async Task<MachineMasterModel> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return await connection.QueryFirstOrDefaultAsync<MachineMasterModel>(
                "usp_GetMachineById",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}

