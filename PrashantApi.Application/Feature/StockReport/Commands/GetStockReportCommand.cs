using MediatR;
using PrashantApi.Application.DTOs.StockReport;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.StockReport.Queries
{
    public class GetStockReportCommand : IRequest<CommandResult>
    {
        public StockReportDto Filter { get; set; } = default!;
    }
}
