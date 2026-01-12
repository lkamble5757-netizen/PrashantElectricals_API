using Dapper;
using PrashantApi.Application.Interfaces.InvoiceMaster;
using PrashantApi.Application.Interfaces.StockUpdateMaster;
using PrashantApi.Domain.Entities.StockUpdateMaster;
using PrashantApi.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Repositories.StockUpdateMaster
{
    public class StockUpdateRepository : IStockUpdateRepository
    {
        private readonly IDbConnectionString _dbConnectionString;

        public StockUpdateRepository(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public async Task<CommandResult> AddAsync(StockUpdateMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var parameters = new DynamicParameters(new
                {
                    entity.Id,
                    entity.StockDate,
                    entity.IsActive,
                    entity.CreatedBy,
                    entity.CreatedOn,
                    Mode = "INSERT"
                });

                var stockUpdateId = await connection.ExecuteScalarAsync<int>(
                    SqlConstants.StockUpdate.SaveStockUpdateMaster,
                    parameters,
                    transaction,
                    commandType: CommandType.StoredProcedure
                );

                if (entity.Items != null && entity.Items.Any())
                {
                    var table = new DataTable();
                    table.Columns.Add("Id", typeof(int));
                    table.Columns.Add("StockUpdateId", typeof(int));
                    table.Columns.Add("ItemId", typeof(int));
                    table.Columns.Add("AvailableStock", typeof(decimal));
                    table.Columns.Add("Usages", typeof(decimal));
                    table.Columns.Add("IsActive", typeof(bool));
                    table.Columns.Add("CreatedBy", typeof(int));
                    table.Columns.Add("CreatedOn", typeof(DateTime));

                    foreach (var item in entity.Items)
                    {
                        table.Rows.Add(
                            item.Id == 0 ? DBNull.Value : item.Id,
                            stockUpdateId,
                            item.ItemId,
                            item.AvailableStock,
                            item.Usages,
                            true,
                            entity.CreatedBy,
                            DateTime.Now
                        );
                    }

                   
                    var dp = new DynamicParameters();
                    dp.Add("@StockUpdateDetails", table.AsTableValuedParameter("dbo.Type_StockUpdateDetails"));
                    dp.Add("@StockUpdateId", stockUpdateId);


                    await connection.ExecuteAsync(
                        SqlConstants.StockUpdate.SaveStockUpdateDetails,
                        dp,
                        transaction,
                        commandType: CommandType.StoredProcedure
                    );
                }

                transaction.Commit();
                return CommandResult.SuccessWithOutput(stockUpdateId);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return CommandResult.Fail(ex.Message);
            }
        }

     
        public async Task<CommandResult> UpdateAsync(StockUpdateMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();
            connection.Open();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id);
                parameters.Add("@StockDate", entity.StockDate);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@ModifiedOn", DateTime.Now);
                parameters.Add("@Mode", "UPDATE");

                await connection.ExecuteAsync(
                    SqlConstants.StockUpdate.SaveStockUpdateMaster,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                if (entity.Items != null && entity.Items.Any())
                {
                    var table = new DataTable();
                    table.Columns.Add("Id", typeof(int));
                    table.Columns.Add("StockUpdateId", typeof(int));
                    table.Columns.Add("ItemId", typeof(int));
                    table.Columns.Add("AvailableStock", typeof(decimal));
                    table.Columns.Add("Usages", typeof(decimal));
                    table.Columns.Add("IsActive", typeof(bool));
                    table.Columns.Add("ModifiedBy", typeof(int));
                    table.Columns.Add("ModifiedOn", typeof(DateTime));

                    foreach (var item in entity.Items)
                    {
                        table.Rows.Add(
                            item.Id,
                            entity.Id,
                            item.ItemId,
                            item.AvailableStock,
                            item.Usages,
                            item.IsActive,
                            entity.ModifiedBy,
                            DateTime.Now
                        );
                    }

                    
                    var dp = new DynamicParameters();
                    dp.Add("@StockUpdateDetails", table.AsTableValuedParameter("dbo.Type_StockUpdateDetails"));
                    dp.Add("@StockUpdateId", entity.Id);


                    await connection.ExecuteAsync(
                        SqlConstants.StockUpdate.SaveStockUpdateDetails,
                        dp,
                        commandType: CommandType.StoredProcedure
                    );
                }

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
                SqlConstants.StockUpdate.GetAllStockUpdates,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

   
        public async Task<dynamic> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            using var multi = await connection.QueryMultipleAsync(
                SqlConstants.StockUpdate.GetStockUpdateById,
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );

            var master = await multi.ReadFirstOrDefaultAsync<dynamic>();
            if (master == null)
                return null;

            var items = (await multi.ReadAsync<dynamic>()).ToList();
            master.Items = items;

            return master;
        }
    }

}
