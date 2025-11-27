using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Infrastructure.Services;
using MediatR;
using PrashantApi.Application.DTOs.InvoiceMaster;
using PrashantApi.Application.Feature.InvoiceMaster.Queries;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Threading.Tasks;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("InvoiceReport")]
        public async Task<ActionResult<CommandResult>> GetInvoiceReport([FromBody] ReportFilterDto filter)
        {
            if (filter == null)
                return BadRequest(CommandResult.Fail("Filter is required"));

            if (filter.FromDate > filter.ToDate)
                return BadRequest(CommandResult.Fail("Invalid date range"));

            var command = new GetInvoiceReportCommand { Filter = filter };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}


