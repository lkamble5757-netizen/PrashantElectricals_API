using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantApi.Application.DTOs.InvoiceMaster;
using PrashantApi.Application.Interfaces.InvoiceMaster;
using PrashantEle.API.PrashantEle.Application.Common;


namespace PrashantApi.Application.Feature.InvoiceMaster.Queries
{
    public class GetInvoiceReportHandler : IRequestHandler<GetInvoiceReportCommand, CommandResult>
    {
        private readonly IReportRepository _repository;

        public GetInvoiceReportHandler(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(GetInvoiceReportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filter = request.Filter ?? throw new ArgumentNullException(nameof(request.Filter));

                if (filter.FromDate > filter.ToDate)
                    return CommandResult.Fail("Invalid date range");

                var data = await _repository.GetInvoiceReportAsync(filter.CustId, filter.FromDate, filter.ToDate);

                return CommandResult.SuccessWithOutput(data);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error generating report: {ex.Message}");
            }
        }
    }
}



