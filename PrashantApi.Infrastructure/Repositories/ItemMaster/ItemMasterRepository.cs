using Dapper;
using PrashantApi.Application.Interfaces.ItemMaster;
using PrashantApi.Application.Interfaces.Logging;
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantApi.Domain.Entities.MachineMaster;
using PrashantApi.Infrastructure.Common;
using PrashantApi.Infrastructure.Connection;
using PrashantApi.Infrastructure.Data;
using PrashantApi.Infrastructure.Repositories;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Repositories.ItemMaster
{
    public class ItemMasterRepository(IDbConnectionString dbConnectionString) : IItemMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<CommandResult> AddAsync(ItemMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ItemCode", entity.ItemCode);
                parameters.Add("@ItemName", entity.ItemName);
                parameters.Add("@CategoryId", entity.CategoryId);
                //parameters.Add("@SubCategoryId", entity.SubCategoryId);
                //parameters.Add("@OpeningStock", entity.OpeningStock);
                //parameters.Add("@OpeningStockAsOn", entity.OpeningStockAsOn);
                //parameters.Add("@ItemStock", entity.ItemStock);
                parameters.Add("@PerUnitPrice", entity.PerUnitPrice);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@IsActive", entity.IsActive);
                //parameters.Add("@LedgerId", entity.LedgerId);
                parameters.Add("@HsnNo", entity.HsnNo);
                parameters.Add("@AvailableStock", entity.AvailableStock);
                parameters.Add("@mode", "INSERT");

                var output = await connection.ExecuteAsync(
                    SqlConstants.ItemMaster.ItemMasterr,
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

        public async Task<CommandResult> UpdateAsync(ItemMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@Id", entity.Id);
                parameters.Add("@ItemCode", entity.ItemCode);
                parameters.Add("@ItemName", entity.ItemName);
                parameters.Add("@CategoryId", entity.CategoryId);
                //parameters.Add("@SubCategoryId", entity.SubCategoryId);
                //parameters.Add("@OpeningStock", entity.OpeningStock);
                //parameters.Add("@OpeningStockAsOn", entity.OpeningStockAsOn);
                //parameters.Add("@ItemStock", entity.ItemStock);
                parameters.Add("@PerUnitPrice", entity.PerUnitPrice);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@IsActive", entity.IsActive);
                //parameters.Add("@LedgerId", entity.LedgerId);
                parameters.Add("@HsnNo", entity.HsnNo);
                parameters.Add("@AvailableStock", entity.AvailableStock);
                parameters.Add("@mode", "UPDATE");

                var output = await connection.ExecuteAsync(
                    SqlConstants.ItemMaster.ItemMasterr,
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
                SqlConstants.ItemMaster.GetAllItemMaster,
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
                SqlConstants.ItemMaster.GetItemMasterById,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }

    public async Task<CommandResult> BulkInsertAsync(List<ItemMasterModel> items)
        {
            if (items == null || items.Count == 0)
                return CommandResult.Fail("No item data to insert.");

            using var connection = _dbConnectionString.GetConnection();

            try
            {
                var table = new DataTable();

                table.Columns.Add("ItemCode", typeof(string));
                table.Columns.Add("ItemName", typeof(string));
                table.Columns.Add("CategoryId", typeof(int));
                table.Columns.Add("PerUnitPrice", typeof(decimal));
                table.Columns.Add("HsnNo", typeof(string));
                table.Columns.Add("AvailableStock", typeof(decimal));
                table.Columns.Add("CreatedBy", typeof(int));

                foreach (var item in items)
                {
                    table.Rows.Add(
                        item.ItemCode,
                        item.ItemName,
                        item.CategoryId,
                        item.PerUnitPrice,
                        item.HsnNo,
                        item.AvailableStock,
                        item.CreatedBy
                    );
                }

                var parameters = new DynamicParameters();
                parameters.Add(
                    "@ItemMaster",
                    table.AsTableValuedParameter("dbo.Type_ItemMasterDetails")
                );

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                    SqlConstants.ItemMaster.ImportExcel,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return CommandResult.SuccessWithOutput(result);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }


    }
}