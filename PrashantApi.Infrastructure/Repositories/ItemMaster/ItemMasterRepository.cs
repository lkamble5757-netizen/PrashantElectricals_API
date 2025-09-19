using Dapper;
using PrashantApi.Application.Interfaces.ItemMaster;
using PrashantApi.Application.Interfaces.Logging;
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantApi.Infrastructure.Common;
using PrashantApi.Infrastructure.Connection;
using PrashantApi.Infrastructure.Data;
using PrashantApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PrashantApi.Infrastructure.Repositories
{
    public class ItemMasterRepository(IDbConnectionString dbConnectionString, ILog log, IExecutionContext context, ISqlServerDataAccess _sqlServerDataAccess) : IItemMasterRepository
    {
        //private readonly List<ItemMasterModel> _items = new();

        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;
        private readonly ILog _log = log;
        private readonly IExecutionContext _context = context;
        private readonly ISqlServerDataAccess sqlServerDataAccess = _sqlServerDataAccess;

        public async Task<int> AddAsync(ItemMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0);
            parameters.Add("@ItemCode", entity.ItemCode);
            parameters.Add("@ItemName", entity.ItemName);
            parameters.Add("@CategoryId", entity.CategoryId);
            parameters.Add("@SubCategoryId", entity.SubCategoryId);
            parameters.Add("@OpeningStock", entity.OpeningStock);
            parameters.Add("@OpeningStockAsOn", entity.OpeningStockAsOn);
            parameters.Add("@ItemStock", entity.ItemStock);
            parameters.Add("@PerUnitPrice", entity.PerUnitPrice);
            parameters.Add("@CreatedBy", entity.CreatedBy);
            parameters.Add("@ModifiedBy", entity.ModifiedBy);
            parameters.Add("@IsActive", entity.IsActive);
            parameters.Add("@LedgerId", entity.LedgerId);
            parameters.Add("@HsnNo", entity.HsnNo);
            parameters.Add("@mode", "INSERT");

            return await connection.QuerySingleAsync<int>(
                "usp_SaveItem",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }



        public async Task<int> UpdateAsync(ItemMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", entity.Id);
            parameters.Add("@ItemCode", entity.ItemCode);
            parameters.Add("@ItemName", entity.ItemName);
            parameters.Add("@CategoryId", entity.CategoryId);
            parameters.Add("@SubCategoryId", entity.SubCategoryId);
            parameters.Add("@OpeningStock", entity.OpeningStock);
            parameters.Add("@OpeningStockAsOn", entity.OpeningStockAsOn);
            parameters.Add("@ItemStock", entity.ItemStock);
            parameters.Add("@PerUnitPrice", entity.PerUnitPrice);
            parameters.Add("@CreatedBy", entity.CreatedBy);
            parameters.Add("@ModifiedBy", entity.ModifiedBy);
            parameters.Add("@IsActive", entity.IsActive);
            parameters.Add("@LedgerId", entity.LedgerId);
             parameters.Add("@HsnNo", entity.HsnNo);
            parameters.Add("@mode", "UPDATE");

            return await connection.QuerySingleAsync<int>(
                "usp_SaveItem",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }



        public async Task<List<ItemMasterModel>> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();

            var items = await connection.QueryAsync<ItemMasterModel>(
                "usp_GetAllItems",
                commandType: CommandType.StoredProcedure
            );

            return items.AsList();
        }


        public async Task<ItemMasterModel> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return await connection.QueryFirstOrDefaultAsync<ItemMasterModel>(
                "usp_GetItemById",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }


    }
}
