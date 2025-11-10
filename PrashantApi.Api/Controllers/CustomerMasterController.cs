using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantApi.Application.Feature.CustomerMaster.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.CustomerMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMasterController(IMediator mediator, ICustomerMasterRepository repository) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ICustomerMasterRepository _repository = repository;

        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Create(CustomerMasterDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid Customer data."));

            var command = new AddCustomerMasterCommand { Customer = dto };
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.FailureReason);
            }

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(CustomerMasterDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest(CommandResult.Fail("Invalid Customer data."));

            var command = new UpdateCustomerMasterCommand { Customer = dto };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
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
                return NotFound($"No Customer found with Id {id}");

            return Ok(result);
        }
    }
}
