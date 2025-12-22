//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;
//using PrashantApi.Application.DTOs.Dashboard;
//using PrashantApi.Application.Interfaces.Dashboard;
//using PrashantApi.Infrastructure.Connection;
//using System.Data;
//using PrashantEle.API.PrashantEle.Infrastructure.Constants;

//namespace PrashantApi.Infrastructure.Repositories.Dashboard
//{
//    public class DashboardRepository(IDbConnectionString dbConnectionString) : IDashboardRepository
//    {
//        private readonly IDbConnectionString _db = dbConnectionString;

//        public async Task<DashboardResponseDto> GetDashboardAsync()
//        {
//            using var conn = _db.GetConnection();
//            await conn.OpenAsync();

//            var response = new DashboardResponseDto();

//            // 1) Get counts (multiple single-row result sets)
//            using (var multi = await conn.QueryMultipleAsync(
//                SqlConstants.Dashboard.GetCounts,
//                commandType: CommandType.StoredProcedure))
//            {
//                // First three queries were separate selects in the SP; map them by reading sequentially.
//                // However usp_GetDashboardCounts returns 5 separate single-column result sets in declared order.
//                // We'll read in same order:
//                var totalCustomers = await multi.ReadFirstAsync<int>();
//                var totalOrders = await multi.ReadFirstAsync<int>();
//                var totalRevenue = await multi.ReadFirstAsync<decimal>();
//                var newUsersThisMonth = await multi.ReadFirstAsync<int>();
//                var supportTickets = await multi.ReadFirstAsync<int>();

//                response.Stats = new DashboardStatsDto
//                {
//                    TotalCustomers = totalCustomers,
//                    TotalOrders = totalOrders,
//                    TotalRevenue = totalRevenue,
//                    NewUsers = newUsersThisMonth,
//                    SupportTickets = supportTickets
//                };
//            }

//            // 2) Monthly sales - map to MonthlySalesDto
//            var monthly = await conn.QueryAsync(
//                SqlConstants.Dashboard.GetMonthlySales,
//                //new { Year = year },
//                commandType: CommandType.StoredProcedure
//            );

//            response.MonthlySales = monthly.Select(m => new MonthlySalesDto
//            {
//                Month = m.MonthName,
//                Amount = (decimal)m.MonthlySale,
//                Year = (int)m.SaleYear
//            }).ToList();

//            // 3) Top 5 customers — used here for orderDistribution (top customers as distribution)
//            var topCustomers = await conn.QueryAsync(
//                SqlConstants.Dashboard.GetTop5Customers,
//                //new { Year = year },
//                commandType: CommandType.StoredProcedure
//            );

//            // Convert to OrderDistributionDto — use TotalRevenue as value (front-end can convert to percentage)
//            response.OrderDistribution = topCustomers.Select(t => new OrderDistributionDto
//            {
//                Label = t.CustName ?? $"Customer {t.Id}",
//                Value = (decimal)t.TotalRevenue
//            }).ToList();

//            return response;
//        }
//    }
//}



using Dapper;
using PrashantApi.Application.DTOs.Dashboard;
using PrashantApi.Application.Interfaces.Dashboard;
using PrashantApi.Infrastructure.Connection;
using System.Data;

namespace PrashantApi.Infrastructure.Repositories.Dashboard
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IDbConnectionString _db;

        public DashboardRepository(IDbConnectionString dbConnectionString)
        {
            _db = dbConnectionString;
        }

        public async Task<DashboardResponseDto> GetDashboardAsync()
        {
            using var conn = _db.GetConnection();
            await conn.OpenAsync();

            var response = new DashboardResponseDto();
            var stats = new DashboardStatsDto();

            // ----------------------------------------------------
            // 1) READ COUNT SP — returns 4 RESULT SETS sequentially
            // ----------------------------------------------------
            using (var multi = await conn.QueryMultipleAsync(
                "usp_GetDashboardCounts",
                commandType: CommandType.StoredProcedure))
            {
                stats.TotalCustomers = await multi.ReadFirstAsync<int>();      // 1st result set
                stats.TotalOrders = await multi.ReadFirstAsync<int>();         // 2nd result set
                stats.TotalRevenue = await multi.ReadFirstAsync<decimal>();    // 3rd result set
                stats.NewUsers = await multi.ReadFirstAsync<int>();            // 4th result set
            }

            response.Stats = stats;

            // ----------------------------------------------------
            // 2) MONTHLY SALES
            // ----------------------------------------------------
            var monthly = await conn.QueryAsync(
                "usp_GetDashboardMonthlySales",
                commandType: CommandType.StoredProcedure);

            response.MonthlySales = monthly.Select(m => new MonthlySalesDto
            {
                Month = m.MonthName,
                Amount = (decimal)m.MonthlySale,
                Year = (int)m.SaleYear
            }).ToList();

            // ----------------------------------------------------
            // 3) TOP 5 CUSTOMER MONTHLY REVENUE
            // ----------------------------------------------------
            var topCustomers = await conn.QueryAsync(
                "usp_GetTop5CustomerMonthlyRevenue",
                commandType: CommandType.StoredProcedure);

            response.OrderDistribution = topCustomers.Select(t => new OrderDistributionDto
            {
                Label = t.CustName ?? $"Customer {t.Id}",
                Value = (decimal)t.TotalRevenue
            }).ToList();

            return response;
        }
    }
}
