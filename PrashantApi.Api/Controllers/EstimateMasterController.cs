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
    public class EstimateMasterController(IMediator mediator, IEstimateMasterService service) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IEstimateMasterService _service = service;

        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Create(EstimateMasterDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid Estimate data."));

            var command = new AddEstimateMasterCommand { EstimateMaster = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(EstimateMasterDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest(CommandResult.Fail("Invalid Estimate data."));

            var command = new UpdateEstimateMasterCommand { EstimateMaster = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<dynamic>> GetAll() 
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id) 
        {
            var result = await _service.GetByIdAsync(id);
            if (result is not IEnumerable<object> list || !list.Any())
                return NotFound();
            return Ok(result);
        }

        [HttpGet("GetJobNoByCustomerID/{id}")]
        public async Task<ActionResult<dynamic>> GetJobNoByCustomerID(int id)
        {
            var result = await _service.GetJobNoByCustomerID(id);
            return Ok(result);
        }

    }
}
