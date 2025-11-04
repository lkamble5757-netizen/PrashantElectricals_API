using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.Estimate;
using PrashantApi.Application.DTOs.RepairWork;
using PrashantApi.Application.Feature.Estimate.Commands;
using PrashantApi.Application.Feature.RepairWork.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RepairWork;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairWorkController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepairWorkRepository _repository;

        public RepairWorkController(IMediator mediator, IRepairWorkRepository repository) 
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Create(RepairWorkDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid RepairWork data."));

            var command = new AddRepairWorkCommand { RepairWork = dto };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(RepairWorkDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest(CommandResult.Fail("Invalid RepairWork data."));

            var command = new UpdateRepairWorkCommand { RepairWork = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}
