using Dapper;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.Logging;
using PrashantApi.Infrastructure.Common;
using PrashantApi.Infrastructure.Connection;
using PrashantApi.Infrastructure.Data;
using PrashantEle.API.PrashantEle.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Repositories
{
    public class ItemMasterService : IItemMasterService
    {
        private readonly IDbConnectionString _dbConnectionString;
        private readonly ILog _log;
        private readonly IExecutionContext _context;
        private readonly ISqlServerDataAccess sqlServerDataAccess;

        public ItemMasterService(IDbConnectionString dbConnectionString, ILog log, IExecutionContext context, ISqlServerDataAccess _sqlServerDataAccess)
        {
            _dbConnectionString = dbConnectionString;
            _log = log;
            _context = context;
            this.sqlServerDataAccess = _sqlServerDataAccess;

        }

        public async Task<int> AddOrUpdateItemAsync(ItemMasterDto dto)
        {
            using var conn = _dbConnectionString.GetConnection();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", dto.Id);
                parameters.Add("@ItemCode", dto.ItemCode);
                parameters.Add("@ItemName", dto.ItemName);
                parameters.Add("@CategoryId", dto.CategoryId);
                parameters.Add("@SubCategoryId", dto.SubCategoryId);
                parameters.Add("@OpeningStock", dto.OpeningStock);
                parameters.Add("@OpeningStockAsOn", dto.OpeningStockAsOn);
                parameters.Add("@ItemStock", dto.ItemStock);
                parameters.Add("@PerUnitPrice", dto.PerUnitPrice);
                parameters.Add("@CreatedBy", dto.CreatedBy);
                parameters.Add("@ModifiedBy", dto.ModifiedBy);
                parameters.Add("@IsActive", dto.IsActive);
                parameters.Add("@LedgerId", dto.LedgerId);
                parameters.Add("@mode", "INSERT"); 

                var result = await conn.QueryFirstOrDefaultAsync<int>(
                    SqlConstants.ItemMaster.usp_SaveItem,   
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch
            {
                throw;
            }
        }


        public async Task<ItemMasterDto> GetItemByIdAsync(int id)
        {
            using var conn = _dbConnectionString.GetConnection();


            var sql = "SELECT * FROM ItemMaster WHERE Id = @Id";
            return await conn.QueryFirstOrDefaultAsync<ItemMasterDto>(sql, new { Id = id });
        }

        public async Task<List<ItemMasterDto>> GetAllItemsAsync()
        {
            using var conn = _dbConnectionString.GetConnection();


            var sql = "SELECT * FROM ItemMaster";
            var result = await conn.QueryAsync<ItemMasterDto>(sql);
            return result.ToList();
        }

        //public Task<int> UpdateItemMaster(ItemMasterDto dto)
        //{
        //    using var conn = _dbConnectionString.GetConnection();

        //    try
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@Id", dto.Id);
        //        parameter.Add("@ItemCode", dto.ItemCode);
        //        parameter.Add("@ItemName", dto.ItemName);
        //        parameter.Add("@CategoryId", dto.CategoryId);
        //        parameter.Add("@SubCategoryId", dto.SubCategoryId);
        //        parameter.Add("@OpeningStock", dto.OpeningStock);
        //        parameter.Add("@OpeningStockAsOn", dto.OpeningStockAsOn);
        //        parameter.Add("@ItemStock", dto.ItemStock);
        //        parameter.Add("@PerUnitPrice", dto.PerUnitPrice);
        //        parameter.Add("@CreatedBy", dto.CreatedBy);
        //        parameter.Add("@ModifiedBy", dto.ModifiedBy);
        //        parameter.Add("@IsActive", dto.IsActive);
        //        parameter.Add("@LedgerId", dto.LedgerId);
        //        parameter.Add("@mode", "UPDATE");

        //        var result = await conn.QueryFirstOrDefaultAsync<int>(
        //            SqlConstants.ItemMaster.usp_SaveItem,
        //            parameters,
        //            commandType: CommandType.StoredProcedure
        //        );

        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public async Task<int> UpdateItemMaster(ItemMasterDto dto)
        {
            using var conn = _dbConnectionString.GetConnection();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", dto.Id);
                parameters.Add("@ItemCode", dto.ItemCode);
                parameters.Add("@ItemName", dto.ItemName);
                parameters.Add("@CategoryId", dto.CategoryId);
                parameters.Add("@SubCategoryId", dto.SubCategoryId);
                parameters.Add("@OpeningStock", dto.OpeningStock);
                parameters.Add("@OpeningStockAsOn", dto.OpeningStockAsOn);
                parameters.Add("@ItemStock", dto.ItemStock);
                parameters.Add("@PerUnitPrice", dto.PerUnitPrice);
                parameters.Add("@CreatedBy", dto.CreatedBy);
                parameters.Add("@ModifiedBy", dto.ModifiedBy);
                parameters.Add("@IsActive", dto.IsActive);
                parameters.Add("@LedgerId", dto.LedgerId);
                parameters.Add("@mode", "UPDATE"); // ✅ set update mode

                var result = await conn.QueryFirstOrDefaultAsync<int>(
                    SqlConstants.ItemMaster.usp_SaveItem,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch
            {
                throw; // ✅ preserves original stack trace
            }
        }


    }
}
   

