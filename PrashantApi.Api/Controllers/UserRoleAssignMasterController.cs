using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.UserRoleAssignMaster;
using PrashantApi.Application.Feature.UserRoleAssignMaster.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Domain.Entities.UserRoleAssignMaster;
using PrashantApi.Application.Interfaces.UserRoleAssignMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleAssignMasterController(IMediator mediator, IUserRoleAssignMasterRepository repository) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IUserRoleAssignMasterRepository _repository = repository;


        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Create(UserRoleAssignMasterDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid UserRoleAssignMaster data."));

            var command = new AddUserRoleAssignMasterCommand { UserRoleAssignMaster = dto };
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.FailureReason);
            }

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(UserRoleAssignMasterDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest(CommandResult.Fail("Invalid UserRoleAssignMaster data."));

            var command = new UpdateUserRoleAssignMasterCommand { UserRoleAssignMaster = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpGet("GetAllPagging")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var roles = await _repository.GetAllAsync();
            return Ok(roles);
        }


        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            if (role == null || ((ICollection<dynamic>)role).Count == 0)
                return NotFound($"No UserRoleAssign found with Id {id}");

            return Ok(role);
        }

    }
}
                                    