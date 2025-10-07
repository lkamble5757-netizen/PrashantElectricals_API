using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PrashantApi.Application.Interfaces.JobEntry;
using PrashantApi.Domain.Entities.JobEntry;
using PrashantApi.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System.Data;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Infrastructure.Repositories.JobEntry
{
    public class JobEntryRepository(IDbConnectionString dbConnectionString) : IJobEntryRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<CommandResult> AddAsync(JobEntryModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", 0);
                parameters.Add("@JobNo", entity.JobNo);
                parameters.Add("@DateReceived", entity.DateReceived);
                parameters.Add("@CustomerID", entity.CustomerID);
                parameters.Add("@CustomerName", entity.CustomerName);
                parameters.Add("@MachineMake", entity.MachineMake);
                parameters.Add("@Model", entity.Model);
                parameters.Add("@HP", entity.HP);
                parameters.Add("@KW", entity.KW);
                parameters.Add("@RPM", entity.RPM);
                parameters.Add("@SerialNo", entity.SerialNo);
                parameters.Add("@IssueReported", entity.IssueReported);
                parameters.Add("@TechnicianAssigned", entity.TechnicianAssigned);
                parameters.Add("@ExpectedDeliveryDate", entity.ExpectedDeliveryDate);
                parameters.Add("@Status", entity.Status);
                parameters.Add("@Attachments", entity.Attachments);
                parameters.Add("@Remarks", entity.Remarks);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@mode", "INSERT");

                var output = await connection.ExecuteScalarAsync<int>(
                    SqlConstants.JobEntry.usp_JobEntry,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return CommandResult.SuccessWithOutput(output);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }

        public async Task<CommandResult> UpdateAsync(JobEntryModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", entity.ID);
                parameters.Add("@JobNo", entity.JobNo);
                parameters.Add("@DateReceived", entity.DateReceived);
                parameters.Add("@CustomerID", entity.CustomerID);
                parameters.Add("@CustomerName", entity.CustomerName);
                parameters.Add("@MachineMake", entity.MachineMake);
                parameters.Add("@Model", entity.Model);
                parameters.Add("@HP", entity.HP);
                parameters.Add("@KW", entity.KW);
                parameters.Add("@RPM", entity.RPM);
                parameters.Add("@SerialNo", entity.SerialNo);
                parameters.Add("@IssueReported", entity.IssueReported);
                parameters.Add("@TechnicianAssigned", entity.TechnicianAssigned);
                parameters.Add("@ExpectedDeliveryDate", entity.ExpectedDeliveryDate);
                parameters.Add("@Status", entity.Status);
                parameters.Add("@Attachments", entity.Attachments);
                parameters.Add("@Remarks", entity.Remarks);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@mode", "UPDATE");

                var output = await connection.ExecuteScalarAsync<int>(
                    SqlConstants.JobEntry.usp_JobEntry,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return CommandResult.SuccessWithOutput(output);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }


        public async Task<IEnumerable<JobEntryModel>> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();
            return await connection.QueryAsync<JobEntryModel>(
                SqlConstants.JobEntry.usp_GetAllJobEntries,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<JobEntryModel>> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);

            return await connection.QueryAsync<JobEntryModel>(
                SqlConstants.JobEntry.usp_GetJobEntryById,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
