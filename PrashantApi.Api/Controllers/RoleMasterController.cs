using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PrashantApi.Application.DTOs.RoleMaster;
using PrashantApi.Application.Feature.RoleMaster.Commands;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleMasterController(IMediator mediator, IRoleMasterService service) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IRoleMasterService _service = service;

        [HttpPost("Add")]
        public async Task<ActionResult<int>> Add(AddRoleMasterCommand command)
        {
            var newId = await _mediator.Send(command);
            return Ok(newId);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<int>> Update(UpdateRoleMasterCommand command)
        {
            var updatedId = await _mediator.Send(command);
            return Ok(updatedId);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoleMasterDto>>> GetAll()
        {
            var roles = await _service.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<RoleMasterDto>> GetById(int id)
        {
            var role = await _service.GetByIdAsync(id);
            if (role == null)
                return NotFound();

            return Ok(role);
        }
    }
}
