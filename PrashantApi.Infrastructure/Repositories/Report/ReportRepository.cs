using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PrashantApi.Application.DTOs.InvoiceMaster;
using PrashantApi.Application.Interfaces.InvoiceMaster;
using PrashantApi.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System;
using System.Data;



namespace PrashantApi.Infrastructure.Repositories.InvoiceMaster
{
    public class ReportRepository : IReportRepository
    {
        private readonly IDbConnectionString _dbConnectionString;

        public ReportRepository(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public async Task<dynamic> GetInvoiceReportAsync(string custId, DateTime fromDate, DateTime toDate)
        {
            using var connection = _dbConnectionString.GetConnection();
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            var parameters = new DynamicParameters();
            parameters.Add("@CustId", string.IsNullOrWhiteSpace(custId) ? "0" : custId);
            parameters.Add("@FromDate", fromDate.Date);
            parameters.Add("@ToDate", toDate.Date);

            var result = await connection.QueryAsync(
                SqlConstants.Report.GetReport,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}