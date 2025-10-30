using Dapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using PrashantApi.Application.Interfaces.RepairWork;
using PrashantApi.Domain.Entities.RepairWork;
using PrashantApi.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static PrashantEle.API.PrashantEle.Infrastructure.Constants.SqlConstants;

namespace PrashantApi.Infrastructure.Repositories.RepairWork
{
    public class RepairWorkRepository : IRepairWorkRepository
    {
        private readonly IDbConnectionString _dbConnectionString;

        public RepairWorkRepository(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public async Task<CommandResult> AddAsync(RepairWorkModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();
            connection.Open();


            try
            {
                var parameters = new DynamicParameters(new
                {
                    entity.jobNo,
                    entity.StartDate,
                    entity.CompletionDate,
                    entity.WorkDone,
                    entity.LabourCharges,
                    entity.totalrepairwork,
                    entity.Status,
                    entity.CreatedBy,
                    mode = "INSERT"
                });

                var repairWorkId = await connection.ExecuteScalarAsync<int>(
                    SqlConstants.RepairWork.SaveRepairWork,
                    parameters,

                    commandType: CommandType.StoredProcedure
                );

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("RepairWorkId", typeof(int));
                table.Columns.Add("ItemId", typeof(int));
                table.Columns.Add("itemQty", typeof(int));
                table.Columns.Add("pricePerItem", typeof(decimal));
                table.Columns.Add("total", typeof(int));
                table.Columns.Add("IsActive", typeof(bool));
                table.Columns.Add("CreatedBy", typeof(int));


                foreach (var item in entity.Items)
                {
                    table.Rows.Add(0, repairWorkId, item.ItemId, item.itemQty, item.pricePerItem,  item.total, 1, entity.CreatedBy);

                }

                var repairWorks = new DynamicParameters();
                repairWorks.Add("@RepairWorkDetails", table.AsTableValuedParameter("dbo.Type_RepairWorkDetails"));
                repairWorks.Add("@Mode", "INSERT");
                await connection.ExecuteAsync(
                        SqlConstants.RepairWork.SaveRepairWorkItem,
                        repairWorks,

                        commandType: CommandType.StoredProcedure
                    );



                return CommandResult.SuccessWithOutput(repairWorkId);
            }
            catch (Exception ex)
            {

                return CommandResult.Fail(ex.Message);
            }
        }

        


        public async Task<CommandResult> UpdateAsync(RepairWorkModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();
            connection.Open();
            //using var transaction = connection.BeginTransaction();

            try
            {
                var parameters = new DynamicParameters(new
                {
                    entity.Id,
                    entity.jobNo,
                    entity.StartDate,
                    entity.CompletionDate,
                    entity.WorkDone,
                    entity.LabourCharges,
                    entity.totalrepairwork,
                    entity.Status,
                    entity.ModifiedBy,
                    @Mode = "UPDATE"
                });

                await connection.ExecuteAsync(
                    SqlConstants.RepairWork.SaveRepairWork,
                    parameters,
                    //transaction,
                    commandType: CommandType.StoredProcedure
                );

                // Delete old items
                //await connection.ExecuteAsync(
                //    SqlConstants.RepairWork.usp_SaveRepairWorkDetails,
                //    new { RepairWorkId = entity.Id },
                //    transaction,
                //    commandType: CommandType.StoredProcedure
                //);

                // Insert new ones
                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("RepairWorkId", typeof(int));
                table.Columns.Add("ItemId", typeof(int));
                table.Columns.Add("itemQty", typeof(int));
                table.Columns.Add("pricePerItem", typeof(decimal));
                table.Columns.Add("total", typeof(int));
                table.Columns.Add("IsActive", typeof(bool));
                table.Columns.Add("ModifiedBy", typeof(int));

                foreach (var item in entity.Items)
                {
                    table.Rows.Add(item.Id, entity.Id, item.ItemId, item.itemQty, item.pricePerItem, item.total, 1, entity.ModifiedBy);
                }

                var repairWorks = new DynamicParameters();
                repairWorks.Add("@RepairWorkDetails", table.AsTableValuedParameter("dbo.Type_RepairWorkDetails"));
                repairWorks.Add("@Mode", "UPDATE"); // ✅ Removed space before @Mode

                await connection.ExecuteAsync(
                    SqlConstants.RepairWork.SaveRepairWorkItem, // ✅ Call correct SP
                    repairWorks,
                    commandType: CommandType.StoredProcedure
                );


                //transaction.Commit();
                return CommandResult.Success;
            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                return CommandResult.Fail(ex.Message);
            }
        }


        public async Task<List<RepairWorkModel>> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();
            var result = await connection.QueryAsync<RepairWorkModel>(
                SqlConstants.RepairWork.GetAllRepairWork,
                commandType: CommandType.StoredProcedure
            );
            return result.AsList();
        }


        public async Task<RepairWorkModel?> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();

            using var multi = await connection.QueryMultipleAsync(
                SqlConstants.RepairWork.GetRepairWorkById,
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );

            // First result set: main RepairWork record(s)
            var repairWorks = (await multi.ReadAsync<RepairWorkModel>()).ToList();

            // Second result set: all related item records
            var items = (await multi.ReadAsync<RepairWorkItemModel>()).ToList();

            // Map items to their respective RepairWork by RepairWorkId
            foreach (var rw in repairWorks)
            {
                rw.Items = items
                    .Where(i => i.RepairWorkId == rw.Id)
                    .ToList();
            }

            // Return single RepairWork (since GetByIdAsync expects one)
            return repairWorks.FirstOrDefault();
        }


    }
}
