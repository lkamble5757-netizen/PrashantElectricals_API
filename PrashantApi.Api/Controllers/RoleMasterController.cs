using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.RoleMaster;
using PrashantApi.Application.Feature.RoleMaster.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RoleMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleMasterController(IMediator mediator, IRoleMasterRepository repository) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IRoleMasterRepository _repository = repository;

        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Create(RoleMasterDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid Role data."));

            var command = new AddRoleMasterCommand { RoleMaster = dto };
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.FailureReason);
            }

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(RoleMasterDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest(CommandResult.Fail("Invalid Role data."));

            var command = new UpdateRoleMasterCommand { RoleMaster = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var roles = await _repository.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            if (role == null)
                return NotFound();

            return Ok(role);
        }
    }
}
