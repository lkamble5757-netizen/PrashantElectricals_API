using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.Feature.Dashboard.Commands;
using PrashantApi.Application.Interfaces.Dashboard;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController(IMediator mediator, IDashboardRepository repository) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IDashboardRepository _repo = repository;

        [HttpGet]
        public async Task<ActionResult<dynamic>> Get()
        {
            var data = await _repo.GetDashboardAsync();
            //var query = new DashboardCommand { Year = year };
            //var result = await _mediator.Send(new DashboardCommand { Year = year });
            //if (!result.IsSuccess)
            //    return BadRequest(result.FailureReason);

            return Ok(data);
        }
    }
}
