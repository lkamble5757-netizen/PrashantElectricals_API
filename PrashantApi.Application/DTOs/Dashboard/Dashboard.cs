using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrashantApi.Application.DTOs.Dashboard
{
    public class DashboardStatsDto
    {
        public int TotalCustomers { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int NewUsers { get; set; }
    }

    public class OrderDistributionDto
    {
        public string Label { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }

    public class MonthlySalesDto
    {
        public string Month { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int Year { get; set; }
    }

    public class DashboardResponseDto
    {
        public DashboardStatsDto Stats { get; set; } = new();
        public List<OrderDistributionDto> OrderDistribution { get; set; } = new();
        public List<MonthlySalesDto> MonthlySales { get; set; } = new();
    }
}
