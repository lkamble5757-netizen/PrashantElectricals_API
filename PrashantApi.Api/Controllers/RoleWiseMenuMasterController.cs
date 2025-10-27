using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RoleWiseMenuMaster;
using PrashantEle.API.PrashantEle.Application.Common;


namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleWiseMenuMasterController(IMediator mediator, IRoleWiseMenuMasterRepository repository) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IRoleWiseMenuMasterRepository _repository = repository;


        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Create(RoleWiseMenuMasterDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid RoleWiseMenuMaster data."));

            var command = new AddRoleWiseMenuMasterCommand { RoleWiseMenuMaster = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(RoleWiseMenuMasterDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest(CommandResult.Fail("Invalid RoleWiseMenuMaster data."));

            var command = new UpdateRoleWiseMenuMasterCommand { RoleWiseMenuMaster = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpGet("GetAllPagging")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }


        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null || ((ICollection<dynamic>)result).Count == 0)
                return NotFound($"No RoleWiseMenuMaster found with Id {id}");

            return Ok(result);
        }
    }
}