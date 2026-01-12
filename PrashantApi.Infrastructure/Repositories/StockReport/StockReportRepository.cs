using Dapper;
using PrashantApi.Application.DTOs.StockReport;
using PrashantApi.Application.Interfaces.StockReport;
using PrashantApi.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System.Data;

namespace PrashantApi.Infrastructure.Repositories.StockReport
{
    public class StockReportRepository : IStockReportRepository
    {
        private readonly IDbConnectionString _dbConnectionString;

        public StockReportRepository(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public async Task<dynamic> GetStockReportAsync(DateTime fromDate, DateTime toDate)
        {
            using var connection = _dbConnectionString.GetConnection();
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            var parameters = new DynamicParameters();
            parameters.Add("@FromDate", fromDate.Date);
            parameters.Add("@ToDate", toDate.Date);

            var result = await connection.QueryAsync(
                SqlConstants.StockReport.GetStockReport,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}
