using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleWiseMenuMasterController(IMediator mediator, IRoleWiseMenuMasterService service) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IRoleWiseMenuMasterService _service = service;

        [HttpPost("Add")]
        public async Task<ActionResult> Add(AddRoleWiseMenuMasterCommand command)
        {
            var dto = new RoleWiseMenuMasterDto
            {
                RoleId = command.RoleId,
                MenuId = command.MenuId,
                IsActive = command.IsActive,
                IsObsolete = command.IsObsolete,
                CreatedBy = command.CreatedBy
            };

            var response = await _service.AddAsync(dto);

            if (!response.IsSuccess)
                return BadRequest(response.FailureReason);

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateRoleWiseMenuMasterCommand command)
        {
            if (command == null)
                return BadRequest("Invalid request body.");

            var dto = new RoleWiseMenuMasterDto
            {
                Id = command.Id,
                RoleId = command.RoleId,
                MenuId = command.MenuId,
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
            if (role == null || role.Count == 0) // ✅ FIXED: Handle empty list
                return NotFound($"No role found with Id {id}");

            return Ok(role);
        }
    }
}
