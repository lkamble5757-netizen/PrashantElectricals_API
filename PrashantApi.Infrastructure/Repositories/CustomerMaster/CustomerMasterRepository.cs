using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PrashantApi.Application.Interfaces.CustomerMaster;
using PrashantApi.Domain.Entities.CustomerMaster;
using PrashantApi.Infrastructure.Connection;
using System.Data;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;

namespace PrashantApi.Infrastructure.Repositories.CustomerMaster
{
    public class CustomerMasterRepository(IDbConnectionString dbConnectionString) : ICustomerMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<CommandResult> AddAsync(CustomerMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", 0);
                parameters.Add("@CustName", entity.CustName);
                parameters.Add("@CustEmail", entity.CustEmail);
                parameters.Add("@CustPhoneNo", entity.CustPhoneNo);
                parameters.Add("@CustAddress", entity.CustAddress);
                parameters.Add("@GSTNo", entity.GSTNo);
                //parameters.Add("@LedgerCode", entity.LedgerCode);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@mode", "INSERT");

                var output = await connection.ExecuteAsync(
                    SqlConstants.CustomerMaster.CustomerMasterr,
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

        public async Task<CommandResult> UpdateAsync(CustomerMasterModel entity)
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id);
                parameters.Add("@CustName", entity.CustName);
                parameters.Add("@CustEmail", entity.CustEmail);
                parameters.Add("@CustPhoneNo", entity.CustPhoneNo);
                parameters.Add("@CustAddress", entity.CustAddress);
                parameters.Add("@GSTNo", entity.GSTNo);
                //parameters.Add("@LedgerCode", entity.LedgerCode);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@mode", "UPDATE");

                var output = await connection.ExecuteAsync(
                    SqlConstants.CustomerMaster.CustomerMasterr,
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
                SqlConstants.CustomerMaster.GetAllCustomerMaster,
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
                SqlConstants.CustomerMaster.GetCustomerMasterById,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}