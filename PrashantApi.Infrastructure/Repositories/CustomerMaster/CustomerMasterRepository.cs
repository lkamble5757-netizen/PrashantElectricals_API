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

namespace PrashantApi.Infrastructure.Repositories.CustomerMaster
{
    public class CustomerMasterRepository(IDbConnectionString dbConnectionString) : ICustomerMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString = dbConnectionString;

        public async Task<int> AddAsync(CustomerMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Cust_Id", 0);
            parameters.Add("@Cust_Name", entity.Cust_Name);
            parameters.Add("@Cust_Email", entity.Cust_Email);
            parameters.Add("@Cust_PhoneNo", entity.Cust_PhoneNo);
            parameters.Add("@Cust_Address", entity.Cust_Address);
            parameters.Add("@GSTNo", entity.GSTNo);
            parameters.Add("@CreatedBy", entity.CreatedBy);
            parameters.Add("@IsActive", entity.IsActive);
            parameters.Add("@mode", "INSERT");

            return await connection.QuerySingleAsync<int>(
                "usp_SaveCustomer",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateAsync(CustomerMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Cust_Id", entity.Cust_Id);
            parameters.Add("@Cust_Name", entity.Cust_Name);
            parameters.Add("@Cust_Email", entity.Cust_Email);
            parameters.Add("@Cust_PhoneNo", entity.Cust_PhoneNo);
            parameters.Add("@Cust_Address", entity.Cust_Address);
            parameters.Add("@GSTNo", entity.GSTNo);
            parameters.Add("@ModifiedBy", entity.ModifiedBy);
            parameters.Add("@IsActive", entity.IsActive);
            parameters.Add("@mode", "UPDATE");

            return await connection.QuerySingleAsync<int>(
                "usp_SaveCustomer",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<List<CustomerMasterModel>> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();

            var result = await connection.QueryAsync<CustomerMasterModel>(
                "usp_GetAllCustomers",
                commandType: CommandType.StoredProcedure
            );

            return result.AsList();
        }

        public async Task<CustomerMasterModel> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionString.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Cust_Id", id);

            return await connection.QueryFirstOrDefaultAsync<CustomerMasterModel>(
                "usp_GetCustomerById",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
