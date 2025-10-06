using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PrashantApi.Application.Interfaces.Estimate;
using PrashantApi.Domain.Entities.Estimate;
using PrashantApi.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Data;

namespace PrashantApi.Infrastructure.Repositories.Estimate
{
    public class EstimateRepository(IDbConnectionString dbConnectionString) : IEstimateRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<CommandResult> AddAsync(EstimateModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@Id", 0);
                parameters.Add("@JobNo", entity.JobNo);
                parameters.Add("@EstimateDate", entity.EstimateDate);
                parameters.Add("@EstimatedUser", entity.EstimatedUser);
                parameters.Add("@Remarks", entity.Remarks);
                parameters.Add("@EstimatedParts", entity.EstimatedParts);
                parameters.Add("@EstimatedLabour", entity.EstimatedLabour);
                parameters.Add("@TransportCharges", entity.TransportCharges);
                parameters.Add("@TotalEstimate", entity.TotalEstimate);
                parameters.Add("@IsApproved", entity.IsApproved);
                parameters.Add("@ApprovalDate", entity.ApprovalDate);
                parameters.Add("@ApprovedBy", entity.ApprovedBy);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@Mode", "INSERT");

                var output = await connection.ExecuteScalarAsync<int>(
                    SqlConstants.Estimate.usp_Estimate,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return CommandResult.SuccessWithOutput(output);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }

        public async Task<CommandResult> UpdateAsync(EstimateModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@Id", entity.Id);
                parameters.Add("@JobNo", entity.JobNo);
                parameters.Add("@EstimateDate", entity.EstimateDate);
                parameters.Add("@EstimatedUser", entity.EstimatedUser);
                parameters.Add("@Remarks", entity.Remarks);
                parameters.Add("@EstimatedParts", entity.EstimatedParts);
                parameters.Add("@EstimatedLabour", entity.EstimatedLabour);
                parameters.Add("@TransportCharges", entity.TransportCharges);
                parameters.Add("@TotalEstimate", entity.TotalEstimate);
                parameters.Add("@IsApproved", entity.IsApproved);
                parameters.Add("@ApprovalDate", entity.ApprovalDate);
                parameters.Add("@ApprovedBy", entity.ApprovedBy);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@Mode", "UPDATE");

                var output = await connection.ExecuteScalarAsync<int>(
                    SqlConstants.Estimate.usp_Estimate,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return CommandResult.SuccessWithOutput(output);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }

        public async Task<IEnumerable<EstimateModel>> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();
            return await connection.QueryAsync<EstimateModel>(
                SqlConstants.Estimate.usp_GetAllEstimates,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EstimateModel>> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return await connection.QueryAsync<EstimateModel>(
                SqlConstants.Estimate.usp_GetEstimateById,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
