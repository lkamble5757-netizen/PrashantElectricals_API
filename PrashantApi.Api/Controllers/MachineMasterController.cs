using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.MachineMaster;
using PrashantApi.Application.Feature.MachineMaster.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.MachineMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineMasterController(IMediator mediator, IMachineMasterRepository repository) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMachineMasterRepository _repository = repository;

        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Add(MachineMasterDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid MachineMaster data."));

            var command = new AddMachineMasterCommand { MachineMaster = dto };
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.FailureReason);
            }

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(MachineMasterDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest(CommandResult.Fail("Invalid MachineMaster data."));

            var command = new UpdateMachineMasterCommand { MachineMaster = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var machines = await _repository.GetAllAsync();
            return Ok(machines);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            var machine = await _repository.GetByIdAsync(id);
            if (machine == null || ((ICollection<dynamic>)machine).Count == 0)
                return NotFound($"No Machine found with Id {id}");

            return Ok(machine);
        }
    }
}