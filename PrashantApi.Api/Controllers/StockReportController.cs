using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.StockReport;
using PrashantApi.Application.Feature.StockReport.Queries;
using PrashantApi.Application.Interfaces.ChallanMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockReportController : ControllerBase
    {

        private readonly IMediator _mediator;
 
        public StockReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("StockReport")]
        public async Task<ActionResult<CommandResult>> GetStockReport([FromBody] StockReportDto filter)
        {
            if (filter == null)
                return BadRequest(CommandResult.Fail("Filter is required"));

            if (filter.FromDate > filter.ToDate)
                return BadRequest(CommandResult.Fail("Invalid date range"));

            var command = new GetStockReportCommand { Filter = filter };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
