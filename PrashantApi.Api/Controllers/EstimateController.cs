using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PrashantApi.Application.DTOs.Estimate;
using PrashantApi.Application.Feature.Estimate.Commands;
using PrashantApi.Application.Interfaces;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController(IMediator mediator, IEstimateService service) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IEstimateService _service = service;

        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Add(AddEstimateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(UpdateEstimateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EstimateDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<IEnumerable<EstimateDto>>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null || !result.Any())
                return NotFound();
            return Ok(result);
        }
    }
}
