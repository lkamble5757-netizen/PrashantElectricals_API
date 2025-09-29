using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PrashantApi.Application.DTOs.UserRoleAssignMaster;
using PrashantApi.Application.Feature.UserRoleAssignMaster.Commands;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleAssignMasterController(IMediator mediator, IUserRoleAssignMasterService service) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IUserRoleAssignMasterService _service = service;

        [HttpPost("Add")]
        public async Task<ActionResult> Add(AddUserRoleAssignMasterCommand command)
        {
            try
            {
                if (command == null)
                    return BadRequest("Invalid request body.");


                var dto = new UserRoleAssignMasterDto
                {
                    UserId = command.UserId,
                    RoleId = command.RoleId,
                    IsActive = command.IsActive,
                    IsObsolete = command.IsObsolete,
                    CreatedBy = command.CreatedBy
                };

                var response = await _service.AddAsync(dto);

                if (!response.IsSuccess)
                    return BadRequest(response.FailureReason);

                return Ok(response);
            }
            catch (Exception)
            {
                      throw; 
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateUserRoleAssignMasterCommand command)
        {
            if (command == null)
                return BadRequest("Invalid request body.");


            var dto = new UserRoleAssignMasterDto
            {
                Id = command.Id,
                UserId = command.UserId,
                RoleId = command.RoleId,
                IsActive = command.IsActive,
                IsObsolete = command.IsObsolete,
                ModifiedBy = command.ModifiedBy
            };

            var response = await _service.UpdateAsync(dto);

            if (!response.IsSuccess)
                return BadRequest(response.FailureReason);

            return Ok(response);
        }

        [HttpGet("GetAllPagging")]
        public async Task<ActionResult> GetAll()
        {
            var roles = await _service.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var role = await _service.GetByIdAsync(id);
            if (role == null || !role.Any())
                return NotFound($"No UserRoleAssign found with Id {id}");

            return Ok(role);
        }
    }
}
