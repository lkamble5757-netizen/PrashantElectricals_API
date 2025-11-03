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
    public class EstimateMasterRepository(IDbConnectionString dbConnectionString) : IEstimateMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<CommandResult> AddAsync(EstimateMasterModel entity)
        {
            using var conn = _dbConnectionString.GetConnection(); 

            try
            {
                // 1️⃣ Insert Master and capture OUTPUT param
                var masterParams = new DynamicParameters();
                masterParams.Add("@EstimateId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                masterParams.Add("@JobNo", entity.JobNo);
                masterParams.Add("@EstimateDate", entity.EstimateDate);
                masterParams.Add("@EstimatedCustomer", entity.EstimatedCustomer);
                masterParams.Add("@Remarks", entity.Remarks);
                masterParams.Add("@EstimatedLabour", entity.EstimatedLabour);
                masterParams.Add("@TransportCharges", entity.TransportCharges);
                masterParams.Add("@TotalEstimate", entity.TotalEstimate);
                masterParams.Add("@IsApproved", entity.IsApproved);
                masterParams.Add("@ApprovalDate", entity.ApprovalDate);
                masterParams.Add("@ApprovedBy", entity.ApprovedBy);
                masterParams.Add("@IsActive", entity.IsActive);
                masterParams.Add("@CreatedBy", entity.CreatedBy);
                masterParams.Add("@Mode", "INSERT");

                await conn.ExecuteAsync(
                    SqlConstants.Estimate.EstimateMaster,
                    masterParams, 
                    commandType: CommandType.StoredProcedure
                );

                // Get OUTPUT param value
                var estimateId = masterParams.Get<int>("@EstimateId");

                // 2️⃣ Prepare Details List with masterId
                if (entity.Items != null && entity.Items.Any())
                {
                    foreach (var item in entity.Items)
                    {
                        item.EstimatedId = estimateId;
                    }

                    // Convert List to DataTable for TVP
                    var tvp = new DataTable();
                    tvp.Columns.Add("EstimatedId", typeof(int));
                    tvp.Columns.Add("ItemId", typeof(string));
                    tvp.Columns.Add("PricePerItem", typeof(decimal));
                    tvp.Columns.Add("ItemQty", typeof(int));
                    tvp.Columns.Add("Total", typeof(decimal));
                    tvp.Columns.Add("IsActive", typeof(bool));
                    tvp.Columns.Add("CreatedBy", typeof(int));

                    foreach (var item in entity.Items)
                    {
                        tvp.Rows.Add(
                            estimateId,
                            item.ItemId,
                            item.PricePerItem,
                            item.ItemQty,
                            item.Total,
                            true,
                            entity.CreatedBy
                        );
                    }
                     
                    var detailParams = new DynamicParameters();
                    detailParams.Add("@EstimatedPartDetailsTVP", tvp.AsTableValuedParameter("dbo.Type_EstimatedPartDetails"));
                    detailParams.Add("@mode", "INSERT");

                    await conn.ExecuteAsync(
                        SqlConstants.Estimate.EstimatedPartDetails,
                        detailParams, 
                        commandType: CommandType.StoredProcedure
                    );
                }
                  
                return CommandResult.SuccessWithOutput(estimateId);
            }
            catch (Exception ex)
            { 
                return CommandResult.Fail(ex.Message);
            }
        }


        public async Task<CommandResult> UpdateAsync(EstimateMasterModel entity)
        {
            try
            {
                using var conn = _dbConnectionString.GetConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EstimateId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@ID", entity.Id);
                parameters.Add("@JobNo", entity.JobNo);
                parameters.Add("@EstimateDate", entity.EstimateDate);
                parameters.Add("@EstimatedCustomer", entity.EstimatedCustomer);
                parameters.Add("@Remarks", entity.Remarks);
                parameters.Add("@EstimatedLabour", entity.EstimatedLabour);
                parameters.Add("@TransportCharges", entity.TransportCharges);
                parameters.Add("@TotalEstimate", entity.TotalEstimate);
                parameters.Add("@IsApproved", entity.IsApproved);
                parameters.Add("@ApprovalDate", entity.ApprovalDate);
                parameters.Add("@ApprovedBy", entity.ApprovedBy);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@Mode", "UPDATE");

                await conn.ExecuteAsync(
                    SqlConstants.Estimate.EstimateMaster,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );



                var estimateId = parameters.Get<int>("@EstimateId");


                // 2️⃣ Prepare Details List with masterId
                if (entity.Items != null && entity.Items.Any())
                {
                    foreach (var item in entity.Items)
                    {
                        item.EstimatedId = estimateId;
                    }

                    // Convert List to DataTable for TVP
                    var tvp = new DataTable();
                    tvp.Columns.Add("EstimatedId", typeof(int));
                    tvp.Columns.Add("ItemId", typeof(string));
                    tvp.Columns.Add("PricePerItem", typeof(decimal));
                    tvp.Columns.Add("ItemQty", typeof(int));
                    tvp.Columns.Add("Total", typeof(decimal));
                    tvp.Columns.Add("IsActive", typeof(bool));
                    tvp.Columns.Add("ModifiedBy", typeof(int));

                    foreach (var item in entity.Items)
                    {
                        tvp.Rows.Add(
                            entity.Id,
                            item.ItemId,
                            item.PricePerItem,
                            item.ItemQty,
                            item.Total,
                            true,
                            entity.ModifiedBy
                        );
                    }

                    var detailParams = new DynamicParameters();
                    detailParams.Add("@EstimatedPartDetailsTVP", tvp.AsTableValuedParameter("dbo.Type_EstimatedPartDetails"));
                    detailParams.Add("@mode", "Update");

                    await conn.ExecuteAsync(
                        SqlConstants.Estimate.EstimatedPartDetails,
                        detailParams,
                        commandType: CommandType.StoredProcedure
                    );
                }

                return CommandResult.SuccessWithOutput(estimateId);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }

        public async Task<dynamic> GetAllAsync() 
        {
            using var conn = _dbConnectionString.GetConnection();
            return await conn.QueryAsync(
                SqlConstants.Estimate.GetAllEstimateMaster,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetEstimatedCustomer()
        {
            using var conn = _dbConnectionString.GetConnection();
            return await conn.QueryAsync(
                SqlConstants.Estimate.GetEstimatedCustomer,
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task<dynamic> GetByIdAsync(int id)
        {
            using var conn = _dbConnectionString.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using var multi = await conn.QueryMultipleAsync(
                SqlConstants.Estimate.GetEstimateMasterById,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            var master = await multi.ReadFirstOrDefaultAsync<EstimateMasterModel>();

            if (master == null)
                return null;

            var details = (await multi.ReadAsync<EstimatedPartDetailsModel>()).ToList();

            master.Items = details;

            return master;
        }

        public async Task<dynamic> GetJobNoByCustomerID(int id)
        {
            using var conn = _dbConnectionString.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await conn.QueryAsync(
                SqlConstants.Estimate.GetJobNoByCustomerID,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }

}
