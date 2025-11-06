using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.JobEntry;
using PrashantApi.Application.Feature.JobEntry.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.JobEntry;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantApi.Domain.Entities.JobEntry;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobEntryController(IMediator mediator, IJobEntryRepository repository) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IJobEntryRepository _repository = repository;

        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Add(JobEntryDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid Job Entry data."));

            var command = new AddJobEntryCommand { JobEntry = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(JobEntryDto dto)
        {
            if (dto == null || dto.ID <= 0)
                return BadRequest(CommandResult.Fail("Invalid Job Entry data."));

            var command = new UpdateJobEntryCommand { JobEntry = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var entries = await _repository.GetAllAsync();
            return Ok(entries);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            var entry = await _repository.GetByIdAsync(id);
            if (entry == null)
                return NotFound();

            return Ok(entry);
        }


        [HttpGet("GetMachineMasterFeildsById/{id}")]
        public async Task<ActionResult<dynamic>> GetMachineMasterFeildsById(int id)
        {
            var result = await _repository.GetMachineMasterFeildsByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
