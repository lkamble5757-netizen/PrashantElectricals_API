using MediatR;
using PrashantApi.Application.DTOs.StockReport;
using PrashantApi.Application.Interfaces.StockReport;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.StockReport.Queries
{
    public class GetStockReportHandler : IRequestHandler<GetStockReportCommand, CommandResult>
    {
        private readonly IStockReportRepository _repository;

        public GetStockReportHandler(IStockReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(GetStockReportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filter = request.Filter;

                if (filter.FromDate > filter.ToDate)
                    return CommandResult.Fail("Invalid date range");

                var data = await _repository.GetStockReportAsync(
                    filter.FromDate,
                    filter.ToDate
                );

                return CommandResult.SuccessWithOutput(data);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error generating stock report: {ex.Message}");
            }
        }
    }
}
