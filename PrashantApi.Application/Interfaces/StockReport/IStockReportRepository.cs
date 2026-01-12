using PrashantApi.Application.DTOs.StockReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.StockReport
{
    public interface IStockReportRepository
    {
        Task<dynamic> GetStockReportAsync(DateTime fromDate, DateTime toDate);

    }
}
