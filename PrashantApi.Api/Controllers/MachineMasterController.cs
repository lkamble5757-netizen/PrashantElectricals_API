using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.MachineMaster;
using PrashantApi.Application.Feature.MachineMaster.Commands;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineMasterController(IMediator mediator, IMachineMasterService service) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMachineMasterService _service = service;

        [HttpPost("Add")]
        public async Task<ActionResult<int>> Add(AddMachineMasterCommand command)
        {
            var newId = await _mediator.Send(command);
            return Ok(newId);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<int>> Update(UpdateMachineMasterCommand command)
        {
            var updatedId = await _mediator.Send(command);
            return Ok(updatedId);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<MachineMasterDto>>> GetAll()
        {
            var machines = await _service.GetAllAsync();
            return Ok(machines);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<MachineMasterDto>> GetById(int id)
        {
            var machine = await _service.GetByIdAsync(id);
            if (machine == null)
                return NotFound();

            return Ok(machine);
        }
    }
}
