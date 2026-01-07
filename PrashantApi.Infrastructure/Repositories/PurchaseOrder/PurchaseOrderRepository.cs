using Dapper;
using PrashantApi.Application.Interfaces.PurchaseOrder;
using PrashantApi.Domain.Entities.PurchaseOrder;
using PrashantApi.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Repositories.PurchaseOrder
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly IDbConnectionString _dbConnectionString;

        public PurchaseOrderRepository(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        

        public async Task<CommandResult> AddAsync(PurchaseOrderMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
            var parameters = new DynamicParameters(new
                {
                    entity.Id,
                    entity.PurchaseOrderNo,
                    entity.CustomerName,
                    entity.OrderDate,
                    entity.TotalAmount,
                    entity.IsActive,
                    entity.CreatedBy,
                    entity.CreatedOn,
                    Mode = "INSERT"
                });

                var PurchaseOrderId = await connection.ExecuteScalarAsync<int>(
                    SqlConstants.PurchaseOrder.SavePurchaseOrderMaster,
                    parameters,
                    transaction,
                    commandType: CommandType.StoredProcedure
                );

                if (entity.Items != null && entity.Items.Any())
                {
                    var table = new DataTable();
                    table.Columns.Add("Id", typeof(int));
                    table.Columns.Add("PurchaseOrderId", typeof(int));
                    table.Columns.Add("ItemId", typeof(int));
                    table.Columns.Add("PricePerItem", typeof(decimal));
                    table.Columns.Add("Quantity", typeof(decimal));
                    table.Columns.Add("UnitType", typeof(string));
                    table.Columns.Add("Total", typeof(decimal));
                    table.Columns.Add("IsActive", typeof(bool));
                    table.Columns.Add("CreatedBy", typeof(int));
                    table.Columns.Add("CreatedOn", typeof(DateTime));

                    foreach (var item in entity.Items)
                    {
                        table.Rows.Add(
                            item.Id,
                            PurchaseOrderId,
                            item.ItemId,
                            item.PricePerItem,
                            item.Quantity,
                            item.UnitType,
                            item.Total,
                            true,
                            entity.CreatedBy,
                            DateTime.Now
                        );
                    }

                    var dp = new DynamicParameters();
                    dp.Add("@PurchaseOrderDetails", table.AsTableValuedParameter("dbo.Type_PurchaseOrderDetails"));
                    dp.Add("@Mode", "INSERT");

                    await connection.ExecuteAsync(
                        SqlConstants.PurchaseOrder.SavePurchaseOrderDetails,
                        dp,
                        transaction,
                        commandType: CommandType.StoredProcedure
                    );
                }

                transaction.Commit();
                return CommandResult.SuccessWithOutput(PurchaseOrderId);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return CommandResult.Fail(ex.Message);
            }
        }


        public async Task<CommandResult> UpdateAsync(PurchaseOrderMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();
            connection.Open();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id);
                parameters.Add("@PurchaseOrderNo", entity.PurchaseOrderNo);
                parameters.Add("@CustomerName", entity.CustomerName);
                parameters.Add("@OrderDate", entity.OrderDate);
                parameters.Add("@TotalAmount", entity.TotalAmount);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@ModifiedOn", DateTime.Now);
                parameters.Add("@Mode", "UPDATE");

                await connection.ExecuteAsync(
                    SqlConstants.PurchaseOrder.SavePurchaseOrderMaster,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                if (entity.Items != null && entity.Items.Any())
                {
                    var table = new DataTable();
                    table.Columns.Add("Id", typeof(int));
                    table.Columns.Add("PurchaseOrderId", typeof(int));
                    table.Columns.Add("ItemId", typeof(int));
                    table.Columns.Add("PricePerItem", typeof(decimal));
                    table.Columns.Add("Quantity", typeof(decimal));
                    table.Columns.Add("QtyUnit", typeof(string));
                    table.Columns.Add("TotalPO", typeof(decimal));
                    table.Columns.Add("IsActive", typeof(bool));
                    table.Columns.Add("ModifiedBy", typeof(int));
                    table.Columns.Add("ModifiedOn", typeof(DateTime));

                    foreach (var item in entity.Items)
                    {
                        table.Rows.Add(
                            item.Id,
                            entity.Id,
                            item.ItemId,
                            item.PricePerItem,
                            item.Quantity,
                            item.UnitType,
                            item.Total,
                            item.IsActive,
                            entity.ModifiedBy,
                            DateTime.Now
                        );
                    }

                    var dp = new DynamicParameters();
                    dp.Add("@PurchaseOrderDetails", table.AsTableValuedParameter("dbo.Type_PurchaseOrderDetails"));
                    dp.Add("@Mode", "UPDATE");

                    await connection.ExecuteAsync(
                        SqlConstants.PurchaseOrder.SavePurchaseOrderDetails,
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
                SqlConstants.PurchaseOrder.GetAllPurchaseOrders,
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
                SqlConstants.PurchaseOrder.GetPurchaseOrderById,
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
