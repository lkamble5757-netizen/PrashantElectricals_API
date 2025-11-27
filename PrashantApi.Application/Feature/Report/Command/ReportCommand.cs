using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantApi.Application.DTOs.InvoiceMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Collections.Generic;

namespace PrashantApi.Application.Feature.InvoiceMaster.Queries
{
    public class GetInvoiceReportCommand : IRequest<CommandResult>
    {
        public ReportFilterDto Filter { get; set; } = default!;
    }
}


