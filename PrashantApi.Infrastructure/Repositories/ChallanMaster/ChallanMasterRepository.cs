using Dapper;
using PrashantApi.Application.Interfaces.ChallanMaster;
using PrashantApi.Domain.Entities.ChallanMaster;
using PrashantApi.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Repositories.ChallanMaster
{
    public class ChallanMasterRepository : IChallanMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString;

        public ChallanMasterRepository(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public async Task<CommandResult> AddAsync(ChallanMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();
            connection.Open();
            try
            {
                var parameters = new DynamicParameters(new
                {
                    entity.ChallanNo,
                    entity.CustomerId,
                    entity.Date,
                    entity.CreatedBy,
                    entity.CreatedOn,
                    Mode = "INSERT"
                });

                var challanId = await connection.ExecuteScalarAsync<int>(
                    SqlConstants.ChallanMaster.SaveChallan,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("ChallanId", typeof(int));
                table.Columns.Add("InvoiceId", typeof(int));
                table.Columns.Add("IsActive", typeof(bool));
                table.Columns.Add("CreatedBy", typeof(int));
                table.Columns.Add("CreatedOn", typeof(DateTime));

                foreach (var item in entity.Details)
                    table.Rows.Add(0, challanId, item.InvoiceId, true, entity.CreatedBy, entity.CreatedOn);

                var challanDetails = new DynamicParameters();
                challanDetails.Add("@ChallanDetails", table.AsTableValuedParameter("dbo.Type_ChallanDetails"));
                challanDetails.Add("@Mode", "INSERT");

                await connection.ExecuteAsync(
                    SqlConstants.ChallanMaster.SaveChallanDetails,
                    challanDetails,
                    commandType: CommandType.StoredProcedure
                );

                return CommandResult.SuccessWithOutput(challanId);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }

        public async Task<CommandResult> UpdateAsync(ChallanMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();
            connection.Open();
            try
            {
                var parameters = new DynamicParameters(new
                {
                    entity.Id,
                    entity.ChallanNo,
                    entity.CustomerId,
                    entity.Date,
                    entity.ModifiedBy,
                    entity.ModifiedOn,
                    Mode = "UPDATE"
                });

                await connection.ExecuteAsync(
                    SqlConstants.ChallanMaster.SaveChallan,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("ChallanId", typeof(int));
                table.Columns.Add("InvoiceId", typeof(int));
                table.Columns.Add("IsActive", typeof(bool));
                table.Columns.Add("ModifiedBy", typeof(int));
                table.Columns.Add("ModifiedOn", typeof(DateTime));

                foreach (var item in entity.Details)
                    table.Rows.Add(item.Id, entity.Id, item.InvoiceId, true, entity.ModifiedBy, entity.ModifiedOn);

                var challanDetails = new DynamicParameters();
                challanDetails.Add("@ChallanDetails", table.AsTableValuedParameter("dbo.Type_ChallanDetails"));
                challanDetails.Add("@Mode", "UPDATE");

                await connection.ExecuteAsync(
                    SqlConstants.ChallanMaster.SaveChallanDetails,
                    challanDetails,
                    commandType: CommandType.StoredProcedure
                );

                return CommandResult.Success;
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
                  SqlConstants.ChallanMaster.GetAllChallan,
                commandType: CommandType.StoredProcedure
            );
            return result.AsList();
        }

        public async Task<dynamic> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();
            using var multi = await connection.QueryMultipleAsync(
                 SqlConstants.ChallanMaster.GetChallanById,
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );

            var challans = (await multi.ReadAsync<dynamic>()).ToList();
            var details = (await multi.ReadAsync<dynamic>()).ToList();

            foreach (var ch in challans)
                ch.Details = details.Where(d => d.ChallanId == ch.Id).ToList();

            return challans.FirstOrDefault();
        }

        public async Task<dynamic> GetInvoicesByCustomerIdAsync(int customerId)
        {
            using var connection = _dbConnectionString.GetConnection();

            try
            {
                var result = await connection.QueryAsync<dynamic>(
                    SqlConstants.ChallanMaster.GetInvoicesByCustomerId,
                    new { CustomerId = customerId },
                    commandType: CommandType.StoredProcedure
                );

                return result.AsList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching invoices for CustomerId {customerId}: {ex.Message}", ex);
            }
        }

        public async Task<dynamic> GetRepairWorkDetailsByJobIdAsync(int jobId)
        {
            using var connection = _dbConnectionString.GetConnection();
            var result = await connection.QueryAsync<dynamic>(
                 SqlConstants.ChallanMaster.GetRepairWorkDetailsByJobId,      
                new { JobId = jobId },                
                commandType: CommandType.StoredProcedure
            );

            return result.AsList();
        }


    }
}
